# SkillSync - Freelancing Services Application

## Table of Contents
1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Application Architecture](#application-architecture)
4. [Features](#features)
5. [Installation](#installation)
6. [Usage](#usage)
7. [Screenshots](#screenshots)
8. [License](#license)

## Introduction
SkillSync is a comprehensive application designed to connect freelancers with clients seeking specialized services. With the rapid evolution of the digital job market, SkillSync aims to offer a user-friendly platform for freelancers to showcase their skills and for clients to find the right professionals for their projects.

### What is Freelancing?
Freelancing involves independent professionals offering specialized services on a project basis. Unlike traditional employment, freelancers have the flexibility to choose their projects and clients, making it a popular option in today's digital era.

### Evolution During COVID-19
The COVID-19 pandemic significantly accelerated the shift towards remote work, increasing the demand for freelance services. Many professionals turned to freelancing due to job losses and the need for flexible work arrangements.

## Technologies Used
SkillSync leverages a modern technology stack to provide a seamless experience for users:

- **Programming Language:** C#
- **Frameworks:** .NET Core, ASP.NET, Angular
- **Frontend Technologies:** HTML, SCSS, Bootstrap, TypeScript, PrimeNG
- **Cloud Services:** Azure (Azure Key Vault, Azure SQL, Azure Storage Account, Azure SignalR, Azure OpenAI, Azure AI Search, Azure Document Intelligence, Azure App Services)
- **APIs:** Google API, LinkedIn API, Exchange Rate API
- **Libraries:** ASP.NET Identity, JWT Token, MailKit, AutoMapper

## Application Architecture
SkillSync's architecture is designed to ensure scalability, security, and performance. The application follows the Onion architecture for a decoupled and maintainable codebase.

### Key Components:
1. **Backend:** Built with ASP.NET Core, providing RESTful APIs.
2. **Frontend:** Developed using Angular for a responsive and dynamic user interface.
3. **Database:** Utilizes Azure SQL for reliable data storage.
4. **Cloud Integration:** Leveraging various Azure services for enhanced functionality and security.

## Features
- **Service Packages:** Users can purchase predefined service packages, simplifying the transaction process.
- **Intelligent Chatbot:** An AI-powered chatbot guides users through the application and answers frequently asked questions.
- **Automated Data Extraction:** Using Azure Document Intelligence to automatically extract data from resumes, streamlining the application process.

## Installation
To set up SkillSync locally, follow these steps:

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/skillsync.git
    cd skillsync
    ```

2. **Backend Setup:**
    - Install the required .NET Core SDK.
    - Navigate to the backend project directory and restore dependencies:
        ```bash
        cd backend
        dotnet restore
        dotnet build
        dotnet run
        ```

3. **Frontend Setup:**
    - Install Node.js and Angular CLI.
    - Navigate to the frontend project directory and install dependencies:
        ```bash
        cd frontend
        npm install
        ng serve
        ```

## Usage
1. **User Registration:** Sign up as a freelancer or client.
2. **Profile Setup:** Freelancers can set up their profiles and list their services.
3. **Service Search:** Clients can browse and purchase service packages.
4. **Project Management:** Both freelancers and clients can manage their projects through the dashboard.

## Screenshots
Here are some screenshots of the SkillSync application:

[![Home Page](HomePage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/c0ffcc03-215e-47d6-a1ab-f2af1f935b00)

[![Contact Page](ContactPage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/c1d76855-9839-49fa-92b6-1f3d5a5b4c08)

[![Login/Register Options](Login-Register-Options)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/20d6f469-ba70-40d5-a775-a92eb8a80654)

[![Register Form](RegisterForm)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/2d7c5522-45ac-4a07-9188-fbe5a0878893)

[![Website Development projects](Project-Page)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/dbccdff4-c928-4652-b83e-39e371cb9a47)

[![Project Page](ProjectPage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/f06147f2-65a3-42cf-8421-68d06f52ea3e)

[![Freelancer Profile](FreelancerProfile)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/d5739fb5-04e7-482d-a44b-e91aa50a0415)

[![Chat Page](ChatPage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/14710712-d707-47bd-a8f2-7550d724de00)

[![Manage Orders Page](ManageOrdersPage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/bfe0f50a-d863-47b6-812d-2c71f29df990)

[![Manage Order Page](ManageOrderPage)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/137fc0b7-810e-46e3-8944-68502432f9cb)

[![Projects Dashboard](ProjectsDashboard)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/5395a562-9f65-4c8f-af55-96405d31f35c)

[![Chatbot Dialog](Chatbot)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/1dfcbb3c-ded4-495c-b560-19151f440297)

*Add Project Steps:*
- [![Overview](Overview)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/af4ba572-ddc2-4852-8524-f88c4e6ae865)
- [![Pricing](Pricing)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/505770a7-964e-4b53-bf51-b01d9c144fd0)
- [![Description & FAQ](DescriptionFaq)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/233270f2-f11a-4ada-9c03-dcb08a618d9b)
- [![Gallery](Gallery)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/2a9c5925-0e05-4f7a-b4a3-cdab9251fec6)
- [![Publish](Publish)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/c0444cad-06e8-4e52-9cb8-60df3f9fcd64)

[![Application Componenets Diagram](Architecture)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/6fe25e68-99f4-4b5a-9667-00ae2a81e2c4)

[![Chatbot Components Diagram](ChatbotArchitecture)](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/6c86f32f-4256-43e5-b250-6b9598aefc78)

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
