using System;
using System.Collections.Generic;
//Using System.Net.Http directive which will enable HttpClient.
using System.Net.Http;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call if you want list of 20 Pokemon
            //GetPokemon();

            //Prints the gen 1 starter pokemon
            GetOnePokemon(1);
            GetOnePokemon(4);
            GetOnePokemon(7);
            Console.ReadLine();
            Console.ReadKey();
        }

        //Method to retrieve all Pokemon from API
        public static async void GetPokemon()
        {
            string baseUrl = "http://pokeapi.co/api/v2/pokemon/";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (content != null)
                            {
                                //Print data to console
                                Console.WriteLine(JObject.Parse(data)["results"]);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }
    
        //Method to retrieve specific Pokemon from API
        public static async void GetOnePokemon(int pokeId)
        {
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
            try
            { 
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                //Parse your data into an object.
                                var dataObj = JObject.Parse(data);
                                PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}", id: $"{dataObj["id"]}", ability: $"{dataObj["abilities"][0]["ability"]["name"]}", height: $"{dataObj["height"]}", weight: $"{dataObj["weight"]}");
                                //Print pokeItem's name to console
                                Console.WriteLine("Pokemon Name: {0}, id: {1}, ability: {2}, height: {3}, weight: {4}", pokeItem.Name, pokeItem.ID, pokeItem.Ability, pokeItem.Height, pokeItem.Weight);
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}