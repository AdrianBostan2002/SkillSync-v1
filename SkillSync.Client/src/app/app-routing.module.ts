import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './web-pages/home-page/home-page.component';
import { LoginResponseComponent } from './components/login-response/login-response/login-response.component';
import { ChooseRoleDialogComponent } from './components/choose-role-dialog/choose-role-dialog.component';
import { LandingPageComponent } from './web-pages/landing-page/landing-page.component';
import { OwnSystemRegisterComponent } from './components/own-system-register/own-system-register.component';
import { FreelancerExperienceComponent } from './components/freelancer-experience/freelancer-experience.component';
import { PostProjectComponent } from './web-pages/post-project/post-project.component';
import { SkillcategoryPageComponent } from './web-pages/skillcategory-page/skillcategory-page.component';
import { SkillsubcategoryPageComponent } from './web-pages/skillsubcategory-page/skillsubcategory-page.component';
import { ProjectPageComponent } from './web-pages/project-page/project-page.component';
import { FreelancerPageComponent } from './web-pages/freelancer-page/freelancer-page.component';
import { ChatPageComponent } from './modules/chat/chat.component';
import { OrdersPageComponent } from './web-pages/orders-page/orders-page.component';
import { OrderPageComponent } from './web-pages/order-page/order-page.component';
import { AppComponent } from './app.component';
import { NavbarLayoutComponent } from './navbar-layout.component';
import { FreelancerProjectsPageComponent } from './web-pages/freelancer-projects-page/freelancer-projects-page.component';
import { AboutUsPageComponent } from './web-pages/about-us-page/about-us-page.component';
import { ChooseLoginProviderPageComponent } from './web-pages/choose-login-provider-page/choose-login-provider-page.component';
import { ChooseRegisterProviderPageComponent } from './web-pages/choose-register-provider-page/choose-register-provider-page.component';
import { OwnSystemLoginPageComponent } from './web-pages/own-system-login-page/own-system-login-page.component';
import { freelancerAuthGuard } from './infrastructure/guards/freelancer-auth.guard';
import { authGuard } from './infrastructure/guards/auth.guard';
import { ContactPageComponent } from './web-pages/contact-page/contact-page.component';
import { EmailConfirmationPageComponent } from './web-pages/email-confirmation-page/email-confirmation-page.component';
import { PostProjectPublishComponent } from './components/post-project-publish/post-project-publish.component';
import { PostProjectOverviewComponent } from './components/post-project-overview/post-project-overview.component';
import { PostProjectPricingComponent } from './components/post-project-pricing/post-project-pricing.component';
import { PostProjectDescriptionFaqComponent } from './components/post-project-description-faq/post-project-description-faq.component';
import { PostProjectGalleryComponent } from './components/post-project-gallery/post-project-gallery.component';

const routes: Routes = [
  {
    path: '',
    component: NavbarLayoutComponent,
    children: [
      { path: '', component: HomePageComponent },
      { path: 'home', component: HomePageComponent },
      { path: "about", component: AboutUsPageComponent },
      { path: "landing-page", component: LandingPageComponent, canActivate: [authGuard] },
      { path: "categories/:categoryName", component: SkillcategoryPageComponent },
      { path: "subcategories/:subCategoryName", component: SkillsubcategoryPageComponent },
      { path: "subcategories/:subCategoryName/skills/:skillName", component: SkillsubcategoryPageComponent },
      { path: "services/:skillName", component: SkillsubcategoryPageComponent },
      { path: "project/:freelancerName/:projectTitle", component: ProjectPageComponent },
      { path: "project/:projectTitle", component: ProjectPageComponent },
      { path: "freelancer/:freelancerName", component: FreelancerPageComponent },
      { path: "chat", component: ChatPageComponent, canActivate: [authGuard] },
      { path: 'chat', loadChildren: () => import('./modules/chat/chat.module').then(m => m.ChatModule), canActivate: [authGuard] },
      { path: "orders", component: OrdersPageComponent, canActivate: [authGuard] },
      { path: "order/:freelancerName/:projectTitle", component: OrderPageComponent, canActivate: [authGuard] },
      { path: "order", component: OrderPageComponent, canActivate: [authGuard] },
      { path: "freelancer-projects", component: FreelancerProjectsPageComponent, canActivate: [freelancerAuthGuard] },
      { path: "contact", component: ContactPageComponent },
      {
        path: 'post-project',
        component: PostProjectComponent,
        canActivate: [freelancerAuthGuard],
        canActivateChild: [freelancerAuthGuard],
        children: [
          { path: '', redirectTo: 'overview', pathMatch: 'full' },
          { path: 'overview', component: PostProjectOverviewComponent },
          { path: 'pricing/:id', component: PostProjectPricingComponent },
          { path: 'description-faq/:id', component: PostProjectDescriptionFaqComponent },
          { path: 'gallery/:id', component: PostProjectGalleryComponent },
          { path: 'publish/:id', component: PostProjectPublishComponent }
        ],
      }
    ]
  },
  {
    path: '',
    component: AppComponent,
    children: [
      { path: "linkedInLogin", component: LoginResponseComponent },
      { path: "choose-role", component: ChooseRoleDialogComponent },
      { path: "register", component: OwnSystemRegisterComponent },
      { path: "freelancer-experience", component: FreelancerExperienceComponent },
      { path: "login", component: OwnSystemLoginPageComponent },
      { path: 'choose-login-provider', component: ChooseLoginProviderPageComponent },
      { path: 'choose-register-provider', component: ChooseRegisterProviderPageComponent },
      { path: 'email-confirmation', component: EmailConfirmationPageComponent }
    ]
  }
];

const routerOptions: ExtraOptions = {
  scrollPositionRestoration: 'enabled',
  anchorScrolling: 'enabled',
};

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
