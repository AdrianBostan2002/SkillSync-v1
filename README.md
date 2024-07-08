# SkillSync - Freelancing Services Application

## Table of Contents
1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Application Architecture](#application-architecture)
4. [Features](#features)
5. [Installation](#installation)
6. [Usage](#usage)
7. [Screenshots](#screenshots)
8. [Contributing](#contributing)
9. [License](#license)

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

![Home Page P1](![image](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/f68adab7-139a-4475-af95-7ed8b9482857))
![Home Page P2](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/6dfd0bbf-01ef-456d-acd8-05220a03d3d0)
![Home Page P3](![image](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/23413a03-90a9-438f-a327-02ac8280191b))
![Home Page P4](![image](https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/317f9a00-472b-44c1-9049-f0891f99a60a))
<a href="https://github.com/AdrianBostan2002/SkillSync-v1/assets/87941004/f68adab7-139a-4475-af95-7ed8b9482857" target="_blank">
   Home Page P5
</a>



*Home Page*

![Freelancer Profile](path/to/freelancer-profile-screenshot.png)
*Freelancer Profile*

![Service Packages](path/to/service-packages-screenshot.png)
*Service Packages*

## Contributing
We welcome contributions from the community. To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and push the branch.
4. Submit a pull request detailing your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
