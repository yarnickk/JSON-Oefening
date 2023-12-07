﻿using PeopleDB;

/*
 * Opdracht: ga op zoek naar de comments die starten met TODO
 * en voeg daar de nodig code toe.
 * De opdrachten zitten in dit bestand, en in het bestand Group.cs
 */

Group group = new Group();
string filePath = "../../../database.json";

// try to load data
LoadFromDisk();

// Menu setup
Menu menu = new Menu();
menu.AddOption('1', "Set Group Name", SetGroupName);
menu.AddOption('2', "Add Person", AddPerson);
menu.AddOption('3', "Show Members", ShowMembers);

menu.Start();

// menu had ended. Save everything
SaveToDisk();


// Hier beginnen de opdrachten
void SetGroupName()
{
    // TODO: vraag om een groepsnaam en wijs die toe aan de groep
    Console.WriteLine("Voer de groepsnaam in:");
    group.Name = Console.ReadLine();
}

void AddPerson()
{
    Person person = new Person();

    // TODO: vraag naam, leeftijd, en hobbies en wijs die toe aan de persoon
    Console.WriteLine("geef naam, leeftijd en hobbies");

    string persoonsnaam = Console.ReadLine();
    person.Name = persoonsnaam;

    string persoonsleeftijd = Console.ReadLine();
    person.Age = persoonsleeftijd;

    string persoonshobby = Console.ReadLine();
    person.Hobbys = persoonshobby;


    group.People.Add(person);
}

void ShowMembers()
{
    // TODO: toon de naam van de groep, en info over alle leden
    Console.WriteLine($"Groepsnaam: {group.Name}");
    foreach (var person in group.People)
    {
        Console.WriteLine($"name: {person.Name}, Age: {person.Age}, Hobbies: {string.Join( ", ", person.Hobbys)}");
    }
}

void SaveToDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep op te slaan. Voeg foutafhandeling toe.
    try
    {
        string json = group.Serialize();
        File.WriteAllText(filePath, json);
        Console.WriteLine("Data saved");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void LoadFromDisk()
{
    // TODO: gebruik de variabele filePath (hierboven gedeclareerd) 
    // om een JSON versie van de groep te laden. Voeg foutafhandeling toe.
    try
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            group = Group.Deserialize(json);
            Console.WriteLine("Data loaded");
        }
        else
        {
            Console.WriteLine("no data found. ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading data: {ex.Message}");
    }
}


