using Microsoft.AspNetCore.Mvc;

namespace Sapper.Controllers
{
    public class SaperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Saper(int width, int height, int bombs)
        {
            List<List<string>> list = new List<List<string>>();

            //Заполнение поля 
            for (int i = 0; i < height; i++)
            {
                list.Add(new List<string>());
                for (int j = 0; j < width; j++)
                    list[i].Add("0");
            }

            //Добавление бомб
            Random random = new Random();
            int bombCounter = 0;
            while (bombCounter < bombs)
            {
                int x = random.Next(0, height);
                int y = random.Next(0, width);
                if (list[x][y] != "#")
                {
                    list[x][y] = "#";
                    bombCounter++;
                }
            }

            //Добавление цифр
            //перебрать вложенными циклами все поле
            //проходится циклом вокруг каждой ячейки 0 и считать counter бомб вокруг нее
           
            int counter;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(list[i][j] != "#")
                    {
                        counter = 0;
                        for (int x = i-1; x < i + 2; x++)
                        {
                            for (int y = j - 1; y < j + 2; y++)
                            {
                                if (x < 0 || y < 0 || x > height - 1 || y > width - 1)
                                    continue;   
                                else
                                {
                                    if (list[x][y] == "#")  
                                        counter++;
                                }
                            }
                        }
                        list[i][j] = (counter).ToString();
                    }
                }
            }


            return View(list);
        }
    }
}
