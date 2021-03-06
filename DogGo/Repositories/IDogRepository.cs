﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();

        List<Dog> GetAllDogsByOwnerId(int Id);
        Dog GetDogById(int Id);
        
       
         void AddDog(Dog dog);
         void UpdateDog(Dog dog);

        void DeleteDog(int dogId);
    }
}
