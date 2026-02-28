using System;
using System.Collections.Generic;
using System.Linq;
using static Programming2._2.Program;


namespace Programming2._2 {
  internal class Program {

    public abstract class Animal {
      public string animalName;
      public int animalAge;
      public string animalHabitat;
      public string typeOfFood;

      //конструктор, требующий обязательной установки имени, возраста, среды обитания и типа пищи. 
      public Animal(string name, int age, string habitat, string food) {
        animalName = name;
        animalAge = age;
        animalHabitat = habitat;
        typeOfFood = food;
      }

      public virtual void GetInfo() { }

    }

    public class Mammal : Animal {
      public bool hasFur;
      public Mammal(string name, int age, string habitat, string food, bool fur)
        : base(name, age, habitat, food) {
        hasFur = fur;
      }

      public override void GetInfo() {
        Console.WriteLine($"Name: {animalName}.\nAge: {animalAge}.\nHabitat: {animalHabitat}.\nFood: {typeOfFood}.\nDoes the animal have fur? {hasFur}.");
        Console.WriteLine("Please enter any button to continue");
        Console.ReadKey();
      }
    }

    public class Bird : Animal {
      public double wingSpan;
      public Bird(string name, int age, string habitat, string food, double span)
        : base(name, age, habitat, food) {
        wingSpan = span;
      }

      public override void GetInfo() {
        Console.WriteLine($"Name: {animalName}.\nAge: {animalAge}.\nHabitat: {animalHabitat}.\nFood: {typeOfFood}.\nWing Span: {wingSpan}.");
        Console.WriteLine("Please enter any button to continue");
        Console.ReadKey();
      }
    }

    public class Fish : Animal {
      public string waterType;
      public Fish(string name, int age, string habitat, string food, string water)
        : base(name, age, habitat, food) {
        waterType = water;
      }

      public override void GetInfo() {
        Console.WriteLine($"Name: {animalName}.\nAge: {animalAge}.\nHabitat: {animalHabitat}.\nFood: {typeOfFood}.\nWater type: {waterType}.");
        Console.WriteLine("Please enter any button to continue");
        Console.ReadKey();
      }
    }

    public class Reptile : Animal {
      public bool isVenomous;
      public Reptile(string name, int age, string habitat, string food, bool venom)
        : base(name, age, habitat, food) {
        isVenomous = venom;
      }

      public override void GetInfo() {
        Console.WriteLine($"Name: {animalName}.\nAge: {animalAge}.\nHabitat: {animalHabitat}.\nFood: {typeOfFood}.\nIs Venomous? {isVenomous}.");
        Console.WriteLine("Please enter any button to continue");
        Console.ReadKey();
      }
    }

    public class Amphibian : Animal {
      public int skinMoisture;
      public Amphibian(string name, int age, string habitat, string food, int moisture)
        : base(name, age, habitat, food) {
        skinMoisture = moisture;
      }

      public override void GetInfo() {
        Console.WriteLine($"Name: {animalName}.\nAge: {animalAge}.\nHabitat: {animalHabitat}.\nFood: {typeOfFood}.\nSkin Moisture: {skinMoisture}.");
        Console.WriteLine("Please enter any button to continue");
        Console.ReadKey();
      }
    }

    public class Zoomanager {
      List<Animal> listForAnimals = new List<Animal>();
      public static Zoomanager s_Instance {
        get {
          if (instance == null) {
            instance = new Zoomanager();
          }
          return instance;
        }
      }
      public void AddAnimalAtList(Animal animal) {
        listForAnimals.Add(animal);
      }
      public void ShowInfo() {
        int zero = 0;
        int one = 1;

        if (listForAnimals.Count == zero) {
          Console.WriteLine("No found animal");
        }
        for (int indexI = 0; indexI < listForAnimals.Count; ++indexI) {
          Console.WriteLine($"\nAnimal {indexI + one}: ");
          listForAnimals[indexI].GetInfo();
        }
        Console.WriteLine();
      }
      private Zoomanager() { }
      private static Zoomanager instance;
    }

    static void Main(string[] args) {

      int zeroButton = 0;
      int secondButton = 2;
      int sixthButton = 6;
      bool isRun = true;

      while (isRun) {
        Console.Write("Enter name animal: ");
        string name = Console.ReadLine();
        while (name.Length < secondButton || !name.All(char.IsLetter)) {
          Console.Write("Please enter the correct animal name.");
          name = Console.ReadLine();
        }
        Console.Write("Enter age animal: ");
        int age = Convert.ToInt32(Console.ReadLine());
        while (age <= zeroButton) {
          Console.Write("Please enter the correct animal age.");
          age = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Enter animal habitat: ");
        string habitat = Console.ReadLine();
        while (!habitat.All(char.IsLetter)) {
          Console.Write("Please enter the correct animal habitat.");
          habitat = Console.ReadLine();
        }
        Console.Write("Enter animal food: ");
        string food = Console.ReadLine();
        while (!food.All(char.IsLetter)) {
          Console.Write("Please enter the correct animal food.");
          food = Console.ReadLine();
        }

        Console.Write("\nWhich subclass would you like to create?\n0 - Finish program\n1 - Mammal\n2 - Bird\n" +
          "3 - Fish\n4 - Reptile\n5 - Amphibian\n6 - Information about all animal.\nAnd your choice: ");
        int classType = Convert.ToInt32(Console.ReadLine());
        while (classType < zeroButton || classType > sixthButton) {
          Console.Write("PLease enter correct number aperation");
          classType = Convert.ToInt32(Console.ReadLine());
        }

        switch (classType) {
          case 0:
            isRun = false;
            break;

          case 1:
            Console.Write("Does the animal have fur? 1 or 0 ");
            bool fur = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            while (fur != true && fur != false) {
              Console.Write("Please enter 1 or 0: ");
              fur = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            }
            Mammal mammalAnimal = new Mammal(name, age, habitat, food, fur);
            Zoomanager.s_Instance.AddAnimalAtList(mammalAnimal);
            mammalAnimal.GetInfo();
            break;

          case 2:
            Console.Write("Please enter the bird wing span: ");
            int span = Convert.ToInt32(Console.ReadLine());
            while (span <= zeroButton) {
              Console.Write("Please enter the correct wing span: ");
              span = Convert.ToInt32(Console.ReadLine());
            }
            Bird littleBird = new Bird(name, age, habitat, food, span);
            Zoomanager.s_Instance.AddAnimalAtList(littleBird);
            littleBird.GetInfo();
            break;

          case 3:
            Console.Write("Enter the water type: fresh or sea");
            string waterType = Console.ReadLine();
            while (waterType != "fresh" || waterType != "sea") {
              Console.Write("Please enter the correct water type: ");
              waterType = Console.ReadLine();
            }
            Fish shark = new Fish(name, age, habitat, food, waterType);
            Zoomanager.s_Instance.AddAnimalAtList(shark);
            shark.GetInfo();
            break;

          case 4:
            Console.WriteLine("");
            bool venom = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            while (venom != true && venom != false) {
              Console.Write("Please enter 1 or 0: ");
              venom = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            }
            Reptile lizard = new Reptile(name, age, habitat, food, venom);
            Zoomanager.s_Instance.AddAnimalAtList(lizard);
            lizard.GetInfo();
            break;

          case 5:
            Console.Write("Please enter the amphibian's humidity level in percent: ");
            int moisture = Convert.ToInt32(Console.ReadLine());
            int moistureBorder = 100;
            while (moisture < zeroButton || moisture > moistureBorder) {
              Console.Write("Please enter the correct amphibian's humidity level in percent.");
              moisture = Convert.ToInt32(Console.ReadLine());
            }
            Amphibian toad = new Amphibian(name, age, habitat, food, moisture);
            Zoomanager.s_Instance.AddAnimalAtList(toad);
            toad.GetInfo();
            break;
          case 6:
            Zoomanager.s_Instance.ShowInfo();
            break;
        }
      }

    }
  }
}
