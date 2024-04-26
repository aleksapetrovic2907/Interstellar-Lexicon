using UnityEngine;
using AP.EnemySystem;
using AP.ProjectileSystem;
using System;
using AP.PowerupsSystem;

namespace AP
{
    public class GameManager : GloballyAccessibleBase<GameManager>
    {
        public event Action<int> OnHealthChange;
        public event Action<int> OnLevelUp;
        public event Action OnGameOver;

        public int Health { get; private set; } = 50;
        public int MaxHealth { get; private set; } = 50;
        public float HealthLeftNormalized => (float)Health / MaxHealth;
        public int Points { get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int ExperienceTillNextLevel { get; private set; }
        public float ExperienceProgressNormalized => (float)Experience / ExperienceTillNextLevel;
        public int WordsWrittenCorrectly { get; private set; }
        public int WordsPerMinute
        {
            get
            {
                var timeSpentTyping = TypingManager.Instance.TimeSpentTyping;
                if (timeSpentTyping == 0) return 0;
                return Mathf.RoundToInt(WordsWrittenCorrectly * 60f / timeSpentTyping);
            }
        }
        public int CurrentCombo { get; private set; } = 0;
        public float GameDurationInSeconds { get; private set; } = 0f;
        public float pointsMultiplierFromPowerup = PointsMultiplierPowerup.ORIGINAL_MULTIPLIER;

        [SerializeField] private float experienceIncreaseFactor;
        [SerializeField] private float pointsPerLetter;

        private const int BASE_EXPERIENCE_REQUIRED_FOR_LEVELUP = 12;
        private const int EXPERIENCE_PER_LETTER = 1;
        private const int DAMAGE_PER_LETTER = 1;

        protected override void Awake()
        {
            base.Awake();
            // todo: LoadModifiersData();
            ExperienceTillNextLevel = BASE_EXPERIENCE_REQUIRED_FOR_LEVELUP;
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            EnemyInstanceManager.Instance.OnEnemyDestroyed += EnemyDestroyed;
            PlanetBehaviour.Instance.OnHitByEnemy += PlanetHit;
        }

        private void Update()
        {
            GameDurationInSeconds += Time.unscaledDeltaTime;
        }

        public void CorrectWordSubmitted() => WordsWrittenCorrectly++;

        private void EnemyDestroyed(Enemy enemy)
        {
            var wordLength = enemy.word.Length;
            Points += (int)(wordLength * pointsPerLetter * pointsMultiplierFromPowerup);
            GainExperience(wordLength);
            CurrentCombo++;
        }

        private void GainExperience(int wordLength)
        {
            Experience += wordLength * EXPERIENCE_PER_LETTER;

            if (Experience < ExperienceTillNextLevel) return;

            Level++;
            Experience %= ExperienceTillNextLevel;
            ExperienceTillNextLevel = (int)(BASE_EXPERIENCE_REQUIRED_FOR_LEVELUP * Mathf.Pow(experienceIncreaseFactor, Level - 1));
            OnLevelUp?.Invoke(Level);
        }

        private void PlanetHit(Enemy enemy)
        {
            LoseHealth(enemy.word.Length * DAMAGE_PER_LETTER);
            CurrentCombo = 0;
        }

        public void GainHealth(int amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
            OnHealthChange?.Invoke(Health);
        }

        public void LoseHealth(int amount)
        {
            Health = Mathf.Clamp(Health - amount, 0, MaxHealth);
            OnHealthChange?.Invoke(Health);
            if (Health == 0) GameLost();
        }

        private void GameLost()
        {
            OnGameOver?.Invoke();
        }
    }
}