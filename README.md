# Andres Brondani net-challenge

Just F5 solution to run it!!

Multiple startup projects are cofigured to run ChatWebApplication and StockConsoleApp projects.

- ChatWebApplication contains chat page with basic .Net identity authentication.
- StockConsoleApp starts WCF StockServiceLibrary and listens to default RabbitMQ queue.

You can also install BotWindowsService with BotWindowsServiceSetup.


# Requirements

This solution requires RabbitMQ message broker service installed on deployment pc (https://www.rabbitmq.com/download.html).