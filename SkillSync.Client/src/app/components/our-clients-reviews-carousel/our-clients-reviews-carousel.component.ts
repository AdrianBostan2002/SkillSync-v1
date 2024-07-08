import { Component } from '@angular/core';

@Component({
  selector: 'app-our-clients-reviews',
  templateUrl: './our-clients-reviews-carousel.component.html',
  styleUrl: './our-clients-reviews-carousel.component.css'
})
export class OurClientsReviewsCarouselComponent {
  clientReviews: { pictureUrl: string, name: string, review: string }[] = [];

  ngOnInit() {
    this.clientReviews = [
      {
        pictureUrl: '../../../assets/img/avatar/portrait-charming-middle-aged-attractive-woman-with-blonde-hair.jpg',
        name: 'Susan L.',
        review: 'We have built a network of trusted freelancers we can depend on when we need something done.'
      },
      {
        pictureUrl: '../../../assets/img/avatar/blond-man-happy-expression.jpg',
        name: 'Mike Johnson',
        review: 'I have been working with SkillSync engineers for several years now. They have all been exceptionally talented, very professional, highly productive, great team players, good communicators, and willing to go above and beyond.'
      },
      {
        pictureUrl: '../../../assets/img/avatar/medium-shot-smiley-senior-man.jpg',
        name: 'Mark S.',
        review: 'The ease of communication and security provided make the process of outsourcing effortless.'
      },
      {
        pictureUrl: '../../../assets/img/avatar/portrait-beautiful-young-woman.jpg',
        name: 'Haley Smith',
        review: 'SkillSync is my go-to source to find high-quality talent I can\'t find elsewhere. I\'ve been very impressed with the breadth and depth of talent they\'ve been able to deliver.'
      },
      {
        pictureUrl: '../../../assets/img/avatar/university-study-abroad-lifestyle-concept.jpg',
        name: 'Kevin Richard',
        review: 'SkillSync has been a great partner for us. They have been able to understand our needs and provide us with the right talent. They have been very responsive and have been able to deliver on time.'
      }
    ];
  }
}
