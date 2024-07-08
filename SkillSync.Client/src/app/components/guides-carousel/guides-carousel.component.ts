import { Component, Input } from '@angular/core';
import { SkillBase } from '../../shared/entities/models/skillbase';

@Component({
  selector: 'app-guides-carousel',
  templateUrl: './guides-carousel.component.html',
  styleUrl: './guides-carousel.component.css'
})
export class GuidesCarouselComponent {
  @Input() skill?: SkillBase;

  guides: { pictureUrl: string; backgroundColor: string; title: string; description: string; }[] = [
    { pictureUrl: 'assets/resources/guides/guides-modern-website.jpg', backgroundColor: '#315959', title: "The Ultimate Guide to Modern Website Development in 2023", description: "Discover the latest techniques, tools, and best practices for building modern websites in 2023. From frontend frameworks to backend technologies, this comprehensive guide covers everything you need to know to create responsive, fast, and secure websites." },
    { pictureUrl: 'assets/resources/guides/guides-wordpress.jpg', backgroundColor: '#D9BBA9', title: "Creating a Professional WordPress Website for Small Businesses", description: "Learn how to leverage the power of WordPress to create a professional website for your small business. From setting up hosting to customizing themes and plugins, this step-by-step guide will help you build a stunning online presence to attract customers and grow your business." },
    { pictureUrl: 'assets/resources/guides/guides-website-design.jpg', backgroundColor: '#548DBF', title: "Mastering Website Design Trends and Technologies in 2023", description: "Stay ahead of the curve with this guide to mastering the latest website design trends and technologies in 2023. Explore topics such as responsive design, mobile optimization, CSS frameworks, and UI/UX principles to create visually stunning and user-friendly websites." },
    { pictureUrl: 'assets/resources/guides/guides-ai.jpg', backgroundColor: '#315959', title: "Demystifying Artificial Intelligence: A Beginner's Guide", description: "Dive into the fascinating world of artificial intelligence (AI) with this beginner-friendly guide. Explore fundamental concepts, common use cases, and popular AI frameworks to understand how AI is shaping the future of technology and innovation." },
    { pictureUrl: 'assets/resources/guides/guides-software-development.jpg', backgroundColor: '#315959', title: "Software Development Best Practices: From Planning to Deployment", description: "Navigate the software development lifecycle like a pro with this guide to best practices. Discover strategies for requirements gathering, agile development, testing, and deployment to deliver high-quality software products on time and within budget." },
    { pictureUrl: 'assets/resources/guides/guides-secure-webapplication.jpg', backgroundColor: '#315959', title: "Building Scalable and Secure Web Applications: A Developer's Guide", description: "Ensure your web applications are scalable, reliable, and secure with this developer's guide. Explore architectural patterns, cloud services, and security practices to design and build web applications that can handle high traffic loads and protect against cyber threats." },
    { pictureUrl: 'assets/resources/guides/guides-cicd.jpg', backgroundColor: '#315959', title: "Continuous Integration and Continuous Deployment (CI/CD) Essentials", description: "Streamline your development workflow and accelerate software delivery with CI/CD practices. Learn how to automate build, test, and deployment processes, integrate with version control systems, and implement CI/CD pipelines to achieve faster time-to-market and higher-quality software releases." },
    { pictureUrl: 'assets/resources/guides/guides-deeplearning.jpg', backgroundColor: '#315959', title: "Exploring Deep Learning: From Theory to Applications", description: "Delve into the world of deep learning, a subset of machine learning that mimics the human brain's neural networks. This guide provides a comprehensive overview of deep learning concepts, architectures like convolutional neural networks (CNNs) and recurrent neural networks (RNNs), and practical applications in image recognition, natural language processing, and more." },
  ];
}
