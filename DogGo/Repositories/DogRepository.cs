﻿using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    
        public class DogRepository
        {
            private readonly IConfiguration _config;

            // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
            public DogRepository(IConfiguration config)
            {
                _config = config;
            }

            public SqlConnection Connection
            {
                get
                {
                    return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                }
            }

            public List<Dog> GetAllDogs()
            {

                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        SELECT Id, [Name], OwnerId, Breed, Notes, ImageUrl
                        FROM Dog
                    ";

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Dog> dogs = new List<Dog>();
                        while (reader.Read())
                        {
                            Dog dog = new Dog
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed")),
                                Notes = reader.GetInt32(reader.GetOrdinal("Notes")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                            };

                            dogs.Add(dog);
                        }

                        reader.Close();

                        return dogs;
                    }
                }
            }

            public Dog GetDogById(int id)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        SELECT Id, [Name], OwnerId, Breed, Notes, ImageUrl
                        FROM Dog
                        WHERE Id = @id
                    ";

                        cmd.Parameters.AddWithValue("@id", id);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Dog dog = new Dog
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                OwnerId = reader.GetInt32(reader.GetOrdinal("Id")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed")),
                                Notes = reader.GetInt32(reader.GetOrdinal("Notes")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                            };

                            reader.Close();
                            return dog;
                        }
                        else
                        {
                            reader.Close();
                            return null;
                        }
                    }
                }
            }
        }
    }
