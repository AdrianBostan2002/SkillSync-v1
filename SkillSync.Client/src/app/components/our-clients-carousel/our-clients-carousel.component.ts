import { Component } from '@angular/core';

@Component({
  selector: 'app-our-clients-carousel',
  templateUrl: './our-clients-carousel.component.html',
  styleUrl: './our-clients-carousel.component.css'
})
export class OurClientsCarouselComponent {
  freelancers: { name: string, description: string, image: string }[] = [];

  ngOnInit() {
    this.freelancers = [
      { name: 'Noah Martinez', description: 'Experienced mobile app developer with expertise in both iOS and Android platforms. He has successfully developed and launched several apps, focusing on seamless user experience and robust functionality.', image: '../../../assets/img/team-2.jpg' },
      { name: 'Sophia Turner', description: 'Seasoned web developer with over 7 years of experience in building responsive and user-friendly websites. She specializes in front-end development using HTML, CSS, and JavaScript frameworks.', image: '../../../assets/img/team-3.jpg' },
      { name: 'Liam Johnson', description: 'Talented graphic designer known for his creative and innovative designs. With a keen eye for detail, he has worked on a variety of projects including branding, logo design, and digital illustrations.', image: '../../../assets/img/team-4.jpg' },
      { name: 'Emma Davis', description: 'Skilled content writer and editor with a passion for storytelling. She has a background in journalism and specializes in creating engaging content for blogs, articles, and social media platforms.', image: '../../../assets/img/team-1.jpg' },
    ]
  }

}
