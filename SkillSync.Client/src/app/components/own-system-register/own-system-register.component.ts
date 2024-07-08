import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../../shared/entities/models/country';
import { RoleType } from '../../shared/enums/role-type';
import { AuthenticationService } from '../../services/authentication.service';
import { OwnSysRegisterRequest } from '../../shared/entities/requests/ownsys-register-request';
import { NotificationService } from '../../services/notification.service';
import { countrySelectedValidator, getPictureFileTypeRestrictions } from '../../shared/utils';
import { FileUploadEvent } from 'primeng/fileupload';
import { CvDataExtractorService } from '../../services/cv-data-extractor.service';

@Component({
  selector: 'app-own-system-register',
  templateUrl: './own-system-register.component.html',
  styleUrl: './own-system-register.component.css'
})
export class OwnSystemRegisterComponent {

  constructor
    (
      private route: ActivatedRoute,
      private router: Router,
      private authenticationService: AuthenticationService,
      private notificationService: NotificationService,
      private cvDataExtractorService: CvDataExtractorService,
      private formBuilder: FormBuilder
    ) { }

  private role?: RoleType;
  uploadedCv?: File;
  nationality?: string;

  profilePictureUrl: string = "";
  uploadProfilePictureMessage: string = "Upload Profile Picture";
  emptyProfilePictureUrl = "assets/resources/no-user-profile-picture.png";

  welcomeMessage: string = "Welcome to our community!";
  registerMessage: string = "To join, please fill out the form below with your details. We're excited to have you on board.";

  jpegAndPngFileType = getPictureFileTypeRestrictions;

  cvFileType = getPictureFileTypeRestrictions + ', application/pdf';

  registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
    password: ['', [Validators.required, Validators.maxLength(50), Validators.pattern('^(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}$')]],
    firstName: ['', [Validators.required, Validators.maxLength(50)]],
    lastName: ['', [Validators.required, Validators.maxLength(50)]],
    phoneNumber: ['', [Validators.required, Validators.pattern("^[0-9()+\\- ]*$")]],
    dateOfBirth: [undefined as unknown as Date, [Validators.required]],
    address: ['', [Validators.required, Validators.maxLength(100)]],
    country: [undefined as unknown as Country, [Validators.required, countrySelectedValidator()]],
    profilePicture: [undefined as unknown as File, [Validators.required]],
  });

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const spValue = parseInt(params['sp']);
      const rValue = parseInt(params['r']);

      this.role = rValue as RoleType;
    });

    this.profilePictureUrl = this.emptyProfilePictureUrl;
  }

  selectedCountry?: Country;

  receiveSelectedCountry(country: Country) {
    this.selectedCountry = country;
    this.registerForm.patchValue({
      country: country
    })
  }

  async onRegister() {
    if (this.registerForm.invalid) {
      return;
    }
    let email = this.registerForm.controls.email.value;
    let password = this.registerForm.controls.password.value;
    let firstName = this.registerForm.controls.firstName.value;
    let lastName = this.registerForm.controls.lastName.value;
    let country = this.registerForm.controls.country.value?.code;
    let profilePicture = this.registerForm.controls.profilePicture.value;

    if (!(email === null || password === null || firstName === null || lastName === null || country === undefined || profilePicture === null)) {
      let registerRequest: OwnSysRegisterRequest = {
        email: this.registerForm.controls.email.value as string,
        password: this.registerForm.controls.password.value as string,
        firstName: this.registerForm.controls.firstName.value as string,
        lastName: this.registerForm.controls.lastName.value as string,
        countryCode: this.selectedCountry?.code ?? "",
        role: this.role ?? RoleType.Freelancer,
        profilePicture: profilePicture
      }

      let registerResponse = await this.authenticationService.ownSystemRegister(registerRequest);
      this.notificationService.displayInfoMessage(registerResponse.message);
      this.router.navigate(["/home"]);
    }
  }

  onUpload(event: FileUploadEvent) {
    const uploadedFiles = event.files;
    const uploadedFile = uploadedFiles[0];

    const reader = new FileReader();
    reader.onload = (e) => {
      let dataUrl = "";
      if (e.target) {
        dataUrl = e.target.result as string;
      }
      this.profilePictureUrl = dataUrl;
      this.registerForm.patchValue({
        profilePicture: uploadedFile
      })
    };
    reader.readAsDataURL(uploadedFile);
  }

  onUploadCv(event: FileUploadEvent) {
    const uploadedFiles = event.files;
    const uploadedFile = uploadedFiles[0];

    const reader = new FileReader();
    reader.readAsDataURL(uploadedFile);
    reader.onload = async () => {
      let cvData = await this.cvDataExtractorService.extractCvData(uploadedFile);
      this.registerForm.patchValue({
        email: cvData.emailAddress,
        firstName: cvData.firstName,
        lastName: cvData.lastName,
        phoneNumber: cvData.phoneNumber,
        address: cvData.fullAddress,
        dateOfBirth: new Date(cvData.dateOfBirth ?? "")
      });
      this.nationality = cvData.nationality;
      this.uploadedCv = uploadedFile;
    };
  }

  validateInput(event: KeyboardEvent) {
    const allowedChars = /[0-9+()\- ]/;
    const inputChar = event.key;

    if (!allowedChars.test(inputChar)) {
      event.preventDefault();
    }
  }
}