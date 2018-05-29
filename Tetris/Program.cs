using Tetris.Logic.Game;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController moveController = new GameController();
            KeyController keyController = new KeyController();
            Engine engine = new Engine(moveController, keyController);



            //Имам лист от студенти. Ако искам да ползвам  students.Contains(student3), в класа Student трябва да имплементирам IEquatable<Student>, който има един метод - Equals (e.g. return this.Name==other.Name)
            //Същия ефект има и ->    students.Contains(s => s.name == student3)
            engine.Run();
        }
    }
}

