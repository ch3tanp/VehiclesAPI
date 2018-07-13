# VehiclesAPI 
This repository contains an sample CRUD API written in C# and ASP.NET Core 2.0.
You will need to have ASP.NET Core 2.0 installed. All the other dependencies will be downloaded from NuGet.
This repository provides basic solution structure that can be used to build Domain-Driven Design (DDD)-based or simply well-factored, SOLID applications using .NET Core.

# Design Decisions and Dependencies
The goal of this sample is to provide a fairly bare-bones starter kit for new projects. It does not include every possible framework, tool, or feature that a particular enterprise application might benefit from. Its choices of technology for things like data access are rooted in what is the most common, accessible technology for most business software developers using Microsoft's technology stack. It doesn't (currently) include extensive support for things like logging, monitoring, or analytics, though these can all be added easily. Below is a list of the technology dependencies it includes, and why they were chosen. Most of these can easily be swapped out for your technology of choice, since the nature of this architecture is to support modularity and encapsulation.

# Entity Framework Core in-memory for rapid prototyping
The in-memory provider in Entity Framework Core makes it easy to rapidly prototype without having to worry about setting up a database. You can build and test against a fast in-memory store, and then swap it out for a real database when you're ready.

# The Test Project
In a real application I will likely have separate test projects, organized based on the kind of test (unit, functional, integration, performance, etc.) or by the project they are testing (Core, Infrastructure, Web), or both. For this simple starter kit, there is just one test project, with folders representing the projects being tested. In terms of dependencies, there are three worth noting:

xunit I'm using xunit because that's what ASP.NET Core uses internally to test the product. It works great and as new versions of ASP.NET Core ship, I'm confident it will continue to work well with it.
