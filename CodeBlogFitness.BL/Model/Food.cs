using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Наименование продукта. 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калорийиность
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Колличество калорий за 100 гр. продукта.
        /// </summary>
        private double CalloriesOneGramm { get { return Calories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name)
        {
            Name = name;

            //TODO: проверка
            
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates) : this(name)
        {
            //TODO: проверки
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
