using System;
using System.Net.Mail;

namespace BirthdayGreetingsKata;

public class BirthdayService
{
    private readonly FileEmployeeRepository fileEmployeeRepository;

    public BirthdayService(FileEmployeeRepository fileEmployeeRepository) {
        this.fileEmployeeRepository = fileEmployeeRepository;
    }

    public void SendGreetings(OurDate ourDate,
        string smtpHost, int smtpPort) {
        var employees = fileEmployeeRepository.GetEmployees();

        foreach (var employee in employees)
        {
            GreetEmployee(ourDate, smtpHost, smtpPort, employee);
        }
    }

    private void GreetEmployee(OurDate ourDate, string smtpHost, int smtpPort, Employee employee) {
        if (employee.IsBirthday(ourDate))
        {
            var recipient = employee.Email;
            var body = "Happy Birthday, dear %NAME%!".Replace("%NAME%",
                    employee.FirstName);
            var subject = "Happy Birthday!";
            SendMessage(smtpHost, smtpPort, "sender@here.com", subject,
                    body, recipient);
        }
    }

    private void SendMessage(string smtpHost, int smtpPort, string sender,
        string subject, string body, string recipient)
    {
        // Create a mail session
        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort
        };

        // Construct the message
        var msg = new MailMessage
        {
            From = new MailAddress(sender),
            Subject = subject,
            Body = body
        };
        msg.To.Add(recipient);

        // Send the message
        SendMessage(msg, smtpClient);
    }

    // made protected for testing :-(
    protected virtual void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }

    static void Main(string[] args)
    {
        var service = new BirthdayService(new FileEmployeeRepository("employee_data.txt"));
        try
        {
            service.SendGreetings(new OurDate("2008/10/08"), "localhost", 25);
        }
        catch (Exception e)
        {
            Console.Write(e.StackTrace);
        }
    }
}