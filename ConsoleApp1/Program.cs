
using ConsoleApp1;

var client = new swaggerClient("https://localhost:7153/", new HttpClient());

//var courses = await client.GetAllCoursesAsync();

//foreach (var course in courses)
//{
//    Console.WriteLine(course.Title);
//}


var c = await client.GetCourseByIdAsync(1);

Console.WriteLine(c.Title);

