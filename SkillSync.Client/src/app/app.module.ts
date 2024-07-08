import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { PasswordModule } from 'primeng/password';
import { HomePageComponent } from './web-pages/home-page/home-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { GoogleSigninButtonModule, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider } from '@abacritt/angularx-social-login';
import { LoginResponseComponent } from './components/login-response/login-response/login-response.component';
import { DividerModule } from 'primeng/divider';
import { ImageModule } from 'primeng/image';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { InputGroupModule } from 'primeng/inputgroup';
import { ToastModule } from 'primeng/toast';
import { MenubarModule } from 'primeng/menubar';
import { MegaMenuModule } from 'primeng/megamenu';
import { DropdownModule } from 'primeng/dropdown';
import { TreeSelectModule } from 'primeng/treeselect';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FileUploadModule } from 'primeng/fileupload';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { BadgeModule } from 'primeng/badge';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ChipModule } from 'primeng/chip';
import { AvatarModule } from 'primeng/avatar';
import { RegisterButtonComponent } from './components/register-button/register-button.component';
import { ChooseRoleDialogComponent } from './components/choose-role-dialog/choose-role-dialog.component';
import { ChooseSocialProvidersMottosComponent } from './components/choose-social-providers-mottos/choose-social-providers-mottos.component';
import { LandingPageComponent } from './web-pages/landing-page/landing-page.component';
import { OwnSystemRegisterComponent } from './components/own-system-register/own-system-register.component';
import { HttpErrorInterceptor } from './infrastructure/interceptors/http-error-interceptor';
import { MessageService } from 'primeng/api';
import { StepsModule } from 'primeng/steps';
import { CardModule } from 'primeng/card';
import { CarouselModule } from 'primeng/carousel';
import { CheckboxModule } from 'primeng/checkbox';
import { InputNumberModule } from 'primeng/inputnumber';
import { FieldsetModule } from 'primeng/fieldset';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { TabViewModule } from 'primeng/tabview';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ProgressBarModule } from 'primeng/progressbar';
import { CountryDropDownComponent } from './components/country-drop-down/country-drop-down.component';
import { FreelancerExperienceComponent } from './components/freelancer-experience/freelancer-experience.component';
import { LanguageDropDownComponent } from './components/language-drop-down/language-drop-down.component';
import { SessionHeaderComponent } from './components/session-header/session-header.component';
import { SkillCategoriesMegaBarComponent } from './components/skill-categories-mega-bar/skill-categories-mega-bar.component';
import { PostProjectComponent } from './web-pages/post-project/post-project.component';
import { RadioButtonModule } from 'primeng/radiobutton';
import { PostProjectOverviewComponent } from './components/post-project-overview/post-project-overview.component';
import { PostProjectPricingComponent } from './components/post-project-pricing/post-project-pricing.component';
import { PostProjectDescriptionFaqComponent } from './components/post-project-description-faq/post-project-description-faq.component';
import { EditorModule } from '@tinymce/tinymce-angular';
import { PaginatorModule } from 'primeng/paginator';
import { SpeedDialModule } from 'primeng/speeddial';
import { RatingModule } from 'primeng/rating';
import { AddEditQuestionComponent } from './components/add-edit-question/add-edit-question.component';
import { PostProjectGalleryComponent } from './components/post-project-gallery/post-project-gallery.component';
import { FreelancerClientRulesComponent } from './components/freelancer-client-rules/freelancer-client-rules.component';
import { PostProjectPublishComponent } from './components/post-project-publish/post-project-publish.component';
import { SkillcategoryPageComponent } from './web-pages/skillcategory-page/skillcategory-page.component';
import { SkillsubcategoryPageComponent } from './web-pages/skillsubcategory-page/skillsubcategory-page.component';
import { GuidesCarouselComponent } from './components/guides-carousel/guides-carousel.component';
import { ProjectPageComponent } from './web-pages/project-page/project-page.component';
import { ChatbotComponent } from './components/chatbot/chatbot.component';
import { FreelancerPageComponent } from './web-pages/freelancer-page/freelancer-page.component';
import { ProjectPreviewCardComponent } from './components/project-preview-card/project-preview-card.component';
import { ReviewsStatisticComponent } from './components/reviews-statistic/reviews-statistic.component';
import { CalendarModule } from 'primeng/calendar';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { PushNotificationComponent } from './components/push-notification/push-notification.component';
import { PlaceOrderDialogComponent } from './components/place-order-dialog/place-order-dialog.component';
import { OrdersPageComponent } from './web-pages/orders-page/orders-page.component';
import { FreelancerOrdersTableComponent } from './components/freelancer-orders-table/freelancer-orders-table.component';
import { OrderPageComponent } from './web-pages/order-page/order-page.component';
import { SliderModule } from 'primeng/slider';
import { OrderTabpanelContentComponent } from './components/order-tabpanel-content/order-tabpanel-content.component';
import { MediaSlideshowComponent } from './components/media-slideshow/media-slideshow.component';
import { AddEditOrderProductDialogComponent } from './components/add-edit-order-product-dialog/add-edit-order-product-dialog.component';
import { EditorDialogComponent } from './components/editor-dialog/editor-dialog.component';
import { PaypalButtonComponent } from './components/paypal-button/paypal-button.component';
import { ReviewDialogComponent } from './components/review-dialog/review-dialog.component';
import { ReviewSectionComponent } from './components/review-section/review-section.component';
import { ServicesSearchBarComponent } from './components/services-search-bar/services-search-bar.component';
import { ProjectFiltersBarComponent } from './components/project-filters-bar/project-filters-bar.component';
import { NavbarLayoutComponent } from './navbar-layout.component';
import { FreelancerProjectsTableComponent } from './components/freelancer-projects-table/freelancer-projects-table.component';
import { FreelancerProjectsPageComponent } from './web-pages/freelancer-projects-page/freelancer-projects-page.component';
import { ProjectsSearchBarComponent } from './components/projects-search-bar/projects-search-bar.component';
import { CurrencyConverterPipe } from './shared/pipes/currency-converter.pipe';
import { UnauthenticatedHeaderComponent } from './components/unauthenticated-header/unauthenticated-header.component';
import { OurClientsCarouselComponent } from './components/our-clients-carousel/our-clients-carousel.component';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { OurClientsReviewsCarouselComponent } from './components/our-clients-reviews-carousel/our-clients-reviews-carousel.component';
import { FooterComponent } from './components/footer/footer.component';
import { AboutChatbotSectionComponent } from './components/about-chatbot-section/about-chatbot-section.component';
import { AboutUsPageComponent } from './web-pages/about-us-page/about-us-page.component';
import { StatsBarComponent } from './components/stats-bar/stats-bar.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { HttpRequestInterceptor } from './infrastructure/interceptors/http-request-interceptor';
import { ChooseLoginProviderPageComponent } from './web-pages/choose-login-provider-page/choose-login-provider-page.component';
import { ChooseRegisterProviderPageComponent } from './web-pages/choose-register-provider-page/choose-register-provider-page.component';
import { BackButtonComponent } from './components/back-button/back-button.component';
import { OwnSystemLoginPageComponent } from './web-pages/own-system-login-page/own-system-login-page.component';
import { CharactersCounterComponent } from './components/characters-counter/characters-counter.component';
import { RouterModule } from '@angular/router';
import { TokenService } from './services/token.service';
import { ContactPageComponent } from './web-pages/contact-page/contact-page.component';
import { EmailConfirmationPageComponent } from './web-pages/email-confirmation-page/email-confirmation-page.component';
import { ServicesListComponent } from './components/services-list/services-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginResponseComponent,
    RegisterButtonComponent,
    ChooseRoleDialogComponent,
    ChooseSocialProvidersMottosComponent,
    LandingPageComponent,
    OwnSystemRegisterComponent,
    CountryDropDownComponent,
    FreelancerExperienceComponent,
    LanguageDropDownComponent,
    SessionHeaderComponent,
    SkillCategoriesMegaBarComponent,
    PostProjectComponent,
    PostProjectOverviewComponent,
    PostProjectPricingComponent,
    PostProjectDescriptionFaqComponent,
    AddEditQuestionComponent,
    PostProjectGalleryComponent,
    FreelancerClientRulesComponent,
    PostProjectPublishComponent,
    SkillcategoryPageComponent,
    SkillsubcategoryPageComponent,
    GuidesCarouselComponent,
    ProjectPageComponent,
    ChatbotComponent,
    FreelancerPageComponent,
    ProjectPreviewCardComponent,
    ReviewsStatisticComponent,
    PushNotificationComponent,
    PlaceOrderDialogComponent,
    OrdersPageComponent,
    FreelancerOrdersTableComponent,
    OrderPageComponent,
    OrderTabpanelContentComponent,
    MediaSlideshowComponent,
    AddEditOrderProductDialogComponent,
    EditorDialogComponent,
    PaypalButtonComponent,
    ReviewDialogComponent,
    ReviewSectionComponent,
    ServicesSearchBarComponent,
    ProjectFiltersBarComponent,
    NavbarLayoutComponent,
    FreelancerProjectsPageComponent,
    FreelancerProjectsTableComponent,
    ProjectsSearchBarComponent,
    CurrencyConverterPipe,
    UnauthenticatedHeaderComponent,
    OurClientsCarouselComponent,
    LoginButtonComponent,
    OurClientsReviewsCarouselComponent,
    FooterComponent,
    AboutChatbotSectionComponent,
    AboutUsPageComponent,
    StatsBarComponent,
    LoadingSpinnerComponent,
    ChooseLoginProviderPageComponent,
    ChooseRegisterProviderPageComponent,
    BackButtonComponent,
    OwnSystemLoginPageComponent,
    CharactersCounterComponent,
    ContactPageComponent,
    EmailConfirmationPageComponent,
    ServicesListComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ButtonModule,
    DialogModule,
    PasswordModule,
    InputTextModule,
    DividerModule,
    ImageModule,
    MessagesModule,
    MessageModule,
    ToastModule,
    InputSwitchModule,
    MenubarModule,
    CardModule,
    CheckboxModule,
    InputTextareaModule,
    InputGroupModule,
    TreeSelectModule,
    FileUploadModule,
    ConfirmDialogModule,
    EditorModule,
    CarouselModule,
    ProgressBarModule,
    ChipModule,
    PaginatorModule,
    SliderModule,
    TabViewModule,
    FieldsetModule,
    StepsModule,
    ProgressSpinnerModule,
    ScrollPanelModule,
    InputNumberModule,
    OverlayPanelModule,
    RadioButtonModule,
    RatingModule,
    CalendarModule,
    AvatarModule,
    BadgeModule,
    MegaMenuModule,
    SpeedDialModule,
    DropdownModule,
    AppRoutingModule,
    NgxDocViewerModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SocialLoginModule,
    GoogleSigninButtonModule,
    RouterModule
  ],
  providers: [
    [TokenService],
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
    MessageService,
    provideClientHydration(),
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '<>'
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    },
    DatePipe,
    CurrencyPipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
