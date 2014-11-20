﻿namespace uLearn.Courses.BasicProgramming.Slides.U11_OOP
{
    [Slide("Практика", "{18A23FCA-B6FB-418D-8FB5-590F4DD203A6}")]
	public class S099_Exercise
	{
        /*
        ## Геометрическая библиотека

        ### Point и Segment
        
        Создайте проект библиотеки Geometry (вы можете выбрать для нее креативное название).
        
        Создайте классы точки (Point) и отрезка (Segment) в двумерном пространстве, а также статический класс Geometry.

        Добавьте в класс Geometry метод CreateSegment, принимающий две точки и возвращающий соответствующий отрезок.

        Разработайте методы, проверяющие, что точка лежит внутри сегмента, в классах Point, Segment и Geometry. Подумайте, где они должны быть динамическими, где статическими, и как избежать дублирования кода.

        ### Rectangle
        
        Создайте класс Rectangle, который хранит информацию о вершинах и сторонах прямоугольника, а также метод Geometry.CreateRectangle, создающий прямоугольник по трем точкам.

        Создайте метод Rotate, который вращает прямоугольник вокруг некоторой точки на некоторое количество градусов.

        ### Модульные тесты

        Куда же без них! Создайте проект модульного тестирования и тесты, которые убедят нас в том, что все созданные вами методы корректно работают.

        ### Рисуем! 
        
        Создайте проект, выбрав его тип как Windows Forms Application и заполните его кодовый файл следующим текстом.

            static class Program
            {
                static Rectangle original;
                static Rectangle processed;
                static Point rotationCenter;

                static void Paint(object sender, PaintEventArgs e)
                {
                    var graphics = e.Graphics;
                }
        
                [STAThread]
                static void Main()
                {
                    var form = new Form();
                    form.Paint += Paint;
                    Application.Run(form);
                }
            }

        В метод Main добавьте инициализацию статических полей.

        В методе Paint разберитесь с методами graphics, и нарисуйте 
        
        * исходный прямоугольник пунктиром, 
        * точку, вокруг которого его следует поворачивать
        * получившийся прямоугольник
         */
    }
}