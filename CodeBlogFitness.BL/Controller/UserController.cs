﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пльзоваетля.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;  

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsresData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsresData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователяю
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
