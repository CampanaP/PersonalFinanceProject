# PersonalFinanceProject
Project created as an exercise to understand how a scalable project works using Modular Architecture.
The solution is organised in this way:
 - Library projects: projects used to interface with external libraries, in an ideal situation they should be Nuget packages
 - Communication projects: projects shared between all modules to know which messages can be sent and received.
 - Module projects: projects divided by domain, they contain the project's business logic
 - Web projects: projects that will be deployed
 - Test projects: projects that for UnitTests and IntegrationTests
 
Communication between the Modules is handled by the Wolverine library (https://wolverinefx.net/) currently implemented via MemoryBus, but easily abstracted to asynchronous communication via RabbitMQ.

**Being an exercise project, it is deliberately not complete.**
