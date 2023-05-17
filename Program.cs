using System;
using System.Net.Http.Headers;
using System.Text.Json;
using drink_info;

class Program
{
    static void Main()
    {
        UserInput userInput = new();
        userInput.GetCategoriesInput();
    }
}