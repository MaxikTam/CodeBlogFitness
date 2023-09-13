using System;
    
namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weigth">Вес</param>
        /// <param name="height">Рост</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weigth,
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пучтым или null", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Именование пола не может быть null", nameof(name));
            }
            if(birthDate < DateTime.Parse("01.01.1900") | birthDate > DateTime.Now )
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            if(weigth <= 0)
            {
                throw new ArgumentException("Вес должен быть положительным", nameof(weigth));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост дложен быть положительным", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weigth;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
