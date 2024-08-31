using EntityFrameWorkCoreTask1.Contexts;
using EntityFrameWorkCoreTask1.Enties;

EntityFrameWorkTask1Context context = new();

Student student = new Student() { FirstName="Elsan",LastName="Mursalov",Gender=0,PhoneNumber=123,SchoolNumber=1234};
context.Students.Add(student);
context.SaveChanges();
