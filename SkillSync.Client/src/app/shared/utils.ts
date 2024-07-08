import { AbstractControl, ValidatorFn } from "@angular/forms";
import { environment } from "../../environments/environment.development";
import { RoleType } from "./enums/role-type";
import { OrderStatus } from "./enums/order-status";
import { PackageType } from "./enums/packages";
import { FileType } from "./enums/file-type";
import { OrderContentType } from "./enums/order-content-type";
import { GetProjectReviewDto } from "./entities/responses/get-project-review-dto";
import { HttpHeaders } from "@angular/common/http";

export function buildRoute(route: string): string {
    return `${environment.apiUrl}${route}`;
}

export function addRangeToArray<T>(targetArray: T[], itemsToAdd: T[]): void {
    targetArray.push(...itemsToAdd);
}

export function countrySelectedValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
        const country = control.value;
        return country ? null : { 'countryNotSelected': true };
    };
}

export function toRoleType(role: string | null) {
    if (role == "SkillScout") {
        return RoleType.SkillScout;
    }
    else if (role == "Freelancer") {
        return RoleType.Freelancer;
    }
    else if (role == "Admin") {
        return RoleType.Administrator;
    }
    return null;
}

export function range(start: number, end: number): number[] {
    return Array.from({ length: end - start + 1 }, (_, index) => start + index);
}

export function removeWhiteSpaceAndCharactersForRoute(name: string) {
    let splitWords = name.split(/[&,. ]/);

    let newCategoryName: string = "";

    if (splitWords.length != 0) {
        newCategoryName = splitWords[0];

        for (let i = 1; i < splitWords.length; i++) {
            if (splitWords[i] != "") {
                newCategoryName = `${newCategoryName}-${splitWords[i]}`;
            }
        }
    }

    if (newCategoryName == "") {
        newCategoryName = name;
    }

    return newCategoryName.toLowerCase();
}

export function orderStatusToString(status: OrderStatus) {
    if (status == OrderStatus.Pending) {
        return "Pending";
    }
    else if (status == OrderStatus.Active) {
        return "Active";
    }
    else if (status == OrderStatus.Delivered) {
        return "Delivered";
    }
    else if (status == OrderStatus.Completed) {
        return "Completed";
    }
    else if (status == OrderStatus.Cancelled) {
        return "Cancelled";
    }

    return "Unknown";
}

export function freelancerOrderStatusToString(status: OrderStatus) {
    if (status == OrderStatus.Pending) {
        return "Pending";
    }
    else if (status == OrderStatus.Active) {
        return "Active";
    }
    else if (status == OrderStatus.Delivered) {
        return "Deliver";
    }
    else if (status == OrderStatus.Completed) {
        return "Complete";
    }
    else if (status == OrderStatus.Cancelled) {
        return "Cancel";
    }

    return "Unknown";
}

export function packageTypeToString(type: PackageType) {
    switch (type) {
        case PackageType.Basic:
            return "Basic";
        case PackageType.Standard:
            return "Standard";
        case PackageType.Premium:
            return "Premium";
        default:
            return "Unknown";
    }
}

export function categoriesIcons(categoryName: string) {
    let icon = "fa fa-code";
    switch (categoryName) {
        case "Programming & Tech":
            icon = "fa fa-code";
            break;
        case "Graphics & Design":
            icon = "fa fa-paint-brush";
            break;
        case "Music & Audio":
            icon = "fa fa-microphone";
            break;
        case "Writing & Translation":
            icon = "fa fa-pencil-alt";
            break;
        case "AI Services":
            icon = "fa fa-robot";
            break;
        case "Data":
            icon = "fa fa-chart-line";
            break;
        case "Photography":
            icon = "fa fa-camera-retro";
            break;
        case "Digital Marketing":
            icon = "fa fa-chart-bar";
            break;
        case "Video & Animation":
            icon = "fa fa-video";
            break;
        case "Business":
            icon = "fa fa-briefcase";
            break;
    }
    return icon;
}

export function extractFirstName(fullName: string) {
    return fullName.split(" ")[0];
}

export function generateTempId(): string {
    const timestamp = new Date().getTime().toString();
    const randomNumber = Math.floor(Math.random() * 1000000).toString();

    return timestamp + '-' + randomNumber;
}

export const jsonHttpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

export function setReviewStatistics(reviews: GetProjectReviewDto[]) {
    let reviewStatistics = [
        { stars: 5, numberOfReviews: 0 },
        { stars: 4, numberOfReviews: 0 },
        { stars: 3, numberOfReviews: 0 },
        { stars: 2, numberOfReviews: 0 },
        { stars: 1, numberOfReviews: 0 }
    ];

    reviews.forEach(review => {
        reviewStatistics?.forEach(reviewStatistic => {
            if (review.stars == reviewStatistic.stars) {
                reviewStatistic.numberOfReviews++;
            }
        });
    });

    return reviewStatistics;
}

export function getPictureFileTypeRestrictions(): string {
    return 'image/jpg, image/jpeg, image/png';
}

export function getVideoFileTypeRestrictions(): string {
    return "video/mp4, video/quicktime";
}

export function getDocumentFileTypeRestrictions(): string {
    return "application/pdf, application/msword, application/vnd.openxmlformats-officedocument.wordprocessingml.document";
}

export function getDocumentFileTypeRestrictionsWithoutWord(): string {
    return "application/pdf";
}

export function getRarFileTypeRestrictions(): string {
    return "application/x-rar-compressed, application/zip";
}

export function getAudioFileTypeRestrictions(): string {
    return "audio/mpeg, audio/wav";
}

export function checkIfDocumentIsWord(content: string) {
    return content.includes(".doc");
}

export function appendFileExtension(blobUrl: string, fileExtension: string): string {
    return blobUrl + '.' + fileExtension;
}

export function fileInputToOrderContentType(fileType: FileType): OrderContentType {
    switch (fileType) {
        case FileType.Image:
            return OrderContentType.Image;
        case FileType.Video:
            return OrderContentType.Video;
        case FileType.Document:
            return OrderContentType.Document;
        case FileType.Audio:
            return OrderContentType.Audio
        default:
            return OrderContentType.Image;
    }
}

export async function downloadBlob(blobUrl: string, fileName: string) {
    try {
        const response = await fetch(blobUrl);

        if (!response.ok) {
            throw new Error('Failed to fetch Blob data');
        }

        const blobData = await response.blob();
        const blob = new Blob([blobData], { type: blobData.type });

        const anchor = document.createElement('a');
        anchor.href = URL.createObjectURL(blob);
        anchor.download = fileName;

        document.body.appendChild(anchor);
        anchor.click();

        document.body.removeChild(anchor);
    } catch (error) {
        console.error('Error downloading Blob:', error);
    }
}

export let countriesAndCode = [
    { name: 'Albania', code: 'AL', nationality: 'Albanian' },
    { name: 'Algeria', code: 'DZ', nationality: 'Algerian' },
    { name: 'Andorra', code: 'AD', nationality: 'Andorran' },
    { name: 'Angola', code: 'AO', nationality: 'Angolan' },
    { name: 'Antigua and Barbuda', code: 'AG', nationality: 'Antiguan' },
    { name: 'Argentina', code: 'AR', nationality: 'Argentinian' },
    { name: 'Armenia', code: 'AM', nationality: 'Armenian' },
    { name: 'Australia', code: 'AU', nationality: 'Australian' },
    { name: 'Austria', code: 'AT', nationality: 'Austrian' },
    { name: 'Azerbaijan', code: 'AZ', nationality: 'Azerbaijani' },
    { name: 'Bahamas', code: 'BS', nationality: 'Bahamian' },
    { name: 'Bahrain', code: 'BH', nationality: 'Bahraini' },
    { name: 'Bangladesh', code: 'BD', nationality: 'Bangladeshi' },
    { name: 'Barbados', code: 'BB', nationality: 'Barbadian' },
    { name: 'Belarus', code: 'BY', nationality: 'Belarusian' },
    { name: 'Belgium', code: 'BE', nationality: 'Belgian' },
    { name: 'Belize', code: 'BZ', nationality: 'Belizean' },
    { name: 'Benin', code: 'BJ', nationality: 'Beninese' },
    { name: 'Bhutan', code: 'BT', nationality: 'Bhutanese' },
    { name: 'Bolivia', code: 'BO', nationality: 'Bolivian' },
    { name: 'Bosnia and Herzegovina', code: 'BA', nationality: 'Bosnian, Herzegovinian' },
    { name: 'Botswana', code: 'BW', nationality: 'Botswanan' },
    { name: 'Brazil', code: 'BR', nationality: 'Brazilian' },
    { name: 'Brunei', code: 'BN', nationality: 'Bruneian' },
    { name: 'Bulgaria', code: 'BG', nationality: 'Bulgarian' },
    { name: 'Burkina Faso', code: 'BF', nationality: 'Burkinabe' },
    { name: 'Burundi', code: 'BI', nationality: 'Burundian' },
    { name: 'Cabo Verde', code: 'CV', nationality: 'Cape Verdian' },
    { name: 'Cambodia', code: 'KH', nationality: 'Cambodian' },
    { name: 'Cameroon', code: 'CM', nationality: 'Cameroonian' },
    { name: 'Canada', code: 'CA', nationality: 'Canadian' },
    { name: 'Central African Republic', code: 'CF', nationality: 'Central African' },
    { name: 'Chad', code: 'TD', nationality: 'Chadian' },
    { name: 'Chile', code: 'CL', nationality: 'Chilean' },
    { name: 'Colombia', code: 'CO', nationality: 'Colombian' },
    { name: 'Comoros', code: 'KM', nationality: 'Comoran' },
    { name: 'Congo (Congo-Brazzaville)', code: 'CG', nationality: 'Congolese' },
    { name: 'Costa Rica', code: 'CR', nationality: 'Costa Rican' },
    { name: 'Croatia', code: 'HR', nationality: 'Croatian' },
    { name: 'Cuba', code: 'CU', nationality: 'Cuban' },
    { name: 'Cyprus', code: 'CY', nationality: 'Cypriot' },
    { name: 'Czechia (Czech Republic)', code: 'CZ', nationality: 'Czech' },
    { name: 'Denmark', code: 'DK', nationality: 'Danish' },
    { name: 'Djibouti', code: 'DJ', nationality: 'Djiboutian' },
    { name: 'Dominica', code: 'DM', nationality: 'Dominican' },
    { name: 'Dominican Republic', code: 'DO', nationality: 'Dominican' },
    { name: 'Ecuador', code: 'EC', nationality: 'Ecuadorian' },
    { name: 'El Salvador', code: 'SV', nationality: 'Salvadoran' },
    { name: 'Equatorial Guinea', code: 'GQ', nationality: 'Equatorial Guinean' },
    { name: 'Eritrea', code: 'ER', nationality: 'Eritrean' },
    { name: 'Estonia', code: 'EE', nationality: 'Estonian' },
    { name: 'Eswatini (fmr. "Swaziland")', code: 'SZ', nationality: 'Swazi' },
    { name: 'Ethiopia', code: 'ET', nationality: 'Ethiopian' },
    { name: 'Fiji', code: 'FJ', nationality: 'Fijian' },
    { name: 'Finland', code: 'FI', nationality: 'Finnish' },
    { name: 'France', code: 'FR', nationality: 'French' },
    { name: 'Gabon', code: 'GA', nationality: 'Gabonese' },
    { name: 'Gambia', code: 'GM', nationality: 'Gambian' },
    { name: 'Georgia', code: 'GE', nationality: 'Georgian' },
    { name: 'Germany', code: 'DE', nationality: 'German' },
    { name: 'Ghana', code: 'GH', nationality: 'Ghanaian' },
    { name: 'Greece', code: 'GR', nationality: 'Greek' },
    { name: 'Grenada', code: 'GD', nationality: 'Grenadian' },
    { name: 'Guatemala', code: 'GT', nationality: 'Guatemalan' },
    { name: 'Guinea', code: 'GN', nationality: 'Guinean' },
    { name: 'Guinea-Bissau', code: 'GW', nationality: 'Guinea-Bissauan' },
    { name: 'Guyana', code: 'GY', nationality: 'Guyanese' },
    { name: 'Haiti', code: 'HT', nationality: 'Haitian' },
    { name: 'Honduras', code: 'HN', nationality: 'Honduran' },
    { name: 'Hungary', code: 'HU', nationality: 'Hungarian' },
    { name: 'Iceland', code: 'IS', nationality: 'Icelander' },
    { name: 'India', code: 'IN', nationality: 'Indian' },
    { name: 'Indonesia', code: 'ID', nationality: 'Indonesian' },
    { name: 'Iran', code: 'IR', nationality: 'Iranian' },
    { name: 'Iraq', code: 'IQ', nationality: 'Iraqi' },
    { name: 'Ireland', code: 'IE', nationality: 'Irish' },
    { name: 'Israel', code: 'IL', nationality: 'Israeli' },
    { name: 'Italy', code: 'IT', nationality: 'Italian' },
    { name: 'Jamaica', code: 'JM', nationality: 'Jamaican' },
    { name: 'Japan', code: 'JP', nationality: 'Japanese' },
    { name: 'Jordan', code: 'JO', nationality: 'Jordanian' },
    { name: 'Kazakhstan', code: 'KZ', nationality: 'Kazakhstani' },
    { name: 'Kenya', code: 'KE', nationality: 'Kenyan' },
    { name: 'Kiribati', code: 'KI', nationality: 'Kiribatian' },
    { name: 'Korea, North', code: 'KP', nationality: 'North Korean' },
    { name: 'Korea, South', code: 'KR', nationality: 'South Korean' },
    { name: 'Kuwait', code: 'KW', nationality: 'Kuwaiti' },
    { name: 'Kyrgyzstan', code: 'KG', nationality: 'Kyrgyzstani' },
    { name: 'Laos', code: 'LA', nationality: 'Laotian' },
    { name: 'Latvia', code: 'LV', nationality: 'Latvian' },
    { name: 'Lebanon', code: 'LB', nationality: 'Lebanese' },
    { name: 'Lesotho', code: 'LS', nationality: 'Mosotho' },
    { name: 'Liberia', code: 'LR', nationality: 'Liberian' },
    { name: 'Libya', code: 'LY', nationality: 'Libyan' },
    { name: 'Liechtenstein', code: 'LI', nationality: 'Liechtensteiner' },
    { name: 'Lithuania', code: 'LT', nationality: 'Lithuanian' },
    { name: 'Luxembourg', code: 'LU', nationality: 'Luxembourger' },
    { name: 'Madagascar', code: 'MG', nationality: 'Malagasy' },
    { name: 'Malawi', code: 'MW', nationality: 'Malawian' },
    { name: 'Malaysia', code: 'MY', nationality: 'Malaysian' },
    { name: 'Maldives', code: 'MV', nationality: 'Maldivian' },
    { name: 'Mali', code: 'ML', nationality: 'Malian' },
    { name: 'Malta', code: 'MT', nationality: 'Maltese' },
    { name: 'Marshall Islands', code: 'MH', nationality: 'Marshallese' },
    { name: 'Mauritania', code: 'MR', nationality: 'Mauritanian' },
    { name: 'Mauritius', code: 'MU', nationality: 'Mauritian' },
    { name: 'Mexico', code: 'MX', nationality: 'Mexican' },
    { name: 'Micronesia', code: 'FM', nationality: 'Micronesian' },
    { name: 'Moldova', code: 'MD', nationality: 'Moldovan' },
    { name: 'Monaco', code: 'MC', nationality: 'Monegasque' },
    { name: 'Mongolia', code: 'MN', nationality: 'Mongolian' },
    { name: 'Montenegro', code: 'ME', nationality: 'Montenegrin' },
    { name: 'Morocco', code: 'MA', nationality: 'Moroccan' },
    { name: 'Mozambique', code: 'MZ', nationality: 'Mozambican' },
    { name: 'Myanmar', code: 'MM', nationality: 'Burmese' },
    { name: 'Namibia', code: 'NA', nationality: 'Namibian' },
    { name: 'Nauru', code: 'NR', nationality: 'Nauruan' },
    { name: 'Nepal', code: 'NP', nationality: 'Nepalese' },
    { name: 'Netherlands', code: 'NL', nationality: 'Dutch' },
    { name: 'New Zealand', code: 'NZ', nationality: 'New Zealander' },
    { name: 'Nicaragua', code: 'NI', nationality: 'Nicaraguan' },
    { name: 'Niger', code: 'NE', nationality: 'Nigerien' },
    { name: 'Nigeria', code: 'NG', nationality: 'Nigerian' },
    { name: 'North Macedonia', code: 'MK', nationality: 'Macedonian' },
    { name: 'Norway', code: 'NO', nationality: 'Norwegian' },
    { name: 'Oman', code: 'OM', nationality: 'Omani' },
    { name: 'Pakistan', code: 'PK', nationality: 'Pakistani' },
    { name: 'Palau', code: 'PW', nationality: 'Palauan' },
    { name: 'Panama', code: 'PA', nationality: 'Panamanian' },
    { name: 'Papua New Guinea', code: 'PG', nationality: 'Papua New Guinean' },
    { name: 'Paraguay', code: 'PY', nationality: 'Paraguayan' },
    { name: 'Peru', code: 'PE', nationality: 'Peruvian' },
    { name: 'Philippines', code: 'PH', nationality: 'Filipino' },
    { name: 'Poland', code: 'PL', nationality: 'Polish' },
    { name: 'Portugal', code: 'PT', nationality: 'Portuguese' },
    { name: 'Qatar', code: 'QA', nationality: 'Qatari' },
    { name: 'Romania', code: 'RO', nationality: 'Romanian' },
    { name: 'Russia', code: 'RU', nationality: 'Russian' },
    { name: 'Rwanda', code: 'RW', nationality: 'Rwandan' },
    { name: 'Saint Kitts and Nevis', code: 'KN', nationality: 'Kittitian or Nevisian' },
    { name: 'Saint Lucia', code: 'LC', nationality: 'Saint Lucian' },
    { name: 'Saint Vincent and the Grenadines', code: 'VC', nationality: 'Vincentian' },
    { name: 'Samoa', code: 'WS', nationality: 'Samoan' },
    { name: 'San Marino', code: 'SM', nationality: 'San Marinese' },
    { name: 'Sao Tome and Principe', code: 'ST', nationality: 'Sao Tomean' },
    { name: 'Saudi Arabia', code: 'SA', nationality: 'Saudi Arabian' },
    { name: 'Senegal', code: 'SN', nationality: 'Senegalese' },
    { name: 'Serbia', code: 'RS', nationality: 'Serbian' },
    { name: 'Seychelles', code: 'SC', nationality: 'Seychellois' },
    { name: 'Sierra Leone', code: 'SL', nationality: 'Sierra Leonean' },
    { name: 'Singapore', code: 'SG', nationality: 'Singaporean' },
    { name: 'Slovakia', code: 'SK', nationality: 'Slovak' },
    { name: 'Slovenia', code: 'SI', nationality: 'Slovenian' },
    { name: 'Solomon Islands', code: 'SB', nationality: 'Solomon Islander' },
    { name: 'Somalia', code: 'SO', nationality: 'Somali' },
    { name: 'South Africa', code: 'ZA', nationality: 'South African' },
    { name: 'South Sudan', code: 'SS', nationality: 'South Sudanese' },
    { name: 'Spain', code: 'ES', nationality: 'Spanish' },
    { name: 'Sri Lanka', code: 'LK', nationality: 'Sri Lankan' },
    { name: 'Sudan', code: 'SD', nationality: 'Sudanese' },
    { name: 'Suriname', code: 'SR', nationality: 'Surinamese' },
    { name: 'Sweden', code: 'SE', nationality: 'Swedish' },
    { name: 'Switzerland', code: 'CH', nationality: 'Swiss' },
    { name: 'Syria', code: 'SY', nationality: 'Syrian' },
    { name: 'Taiwan', code: 'TW', nationality: 'Taiwanese' },
    { name: 'Tajikistan', code: 'TJ', nationality: 'Tajik' },
    { name: 'Tanzania', code: 'TZ', nationality: 'Tanzanian' },
    { name: 'Thailand', code: 'TH', nationality: 'Thai' },
    { name: 'Timor-Leste', code: 'TL', nationality: 'Timorese' },
    { name: 'Togo', code: 'TG', nationality: 'Togolese' },
    { name: 'Tonga', code: 'TO', nationality: 'Tongan' },
    { name: 'Trinidad and Tobago', code: 'TT', nationality: 'Trinidadian, Tobagonian' },
    { name: 'Tunisia', code: 'TN', nationality: 'Tunisian' },
    { name: 'Turkey', code: 'TR', nationality: 'Turkish' },
    { name: 'Turkmenistan', code: 'TM', nationality: 'Turkmen' },
    { name: 'Tuvalu', code: 'TV', nationality: 'Tuvaluan' },
    { name: 'Uganda', code: 'UG', nationality: 'Ugandan' },
    { name: 'Ukraine', code: 'UA', nationality: 'Ukrainian' },
    { name: 'United Arab Emirates', code: 'AE', nationality: 'Emirati' },
    { name: 'United Kingdom', code: 'GB', nationality: 'British' },
    { name: 'United States of America', code: 'US', nationality: 'American' },
    { name: 'Uruguay', code: 'UY', nationality: 'Uruguayan' },
    { name: 'Uzbekistan', code: 'UZ', nationality: 'Uzbekistani' },
    { name: 'Vanuatu', code: 'VU', nationality: 'Vanuatuan' },
    { name: 'Vatican City', code: 'VA', nationality: 'Vatican' },
    { name: 'Venezuela', code: 'VE', nationality: 'Venezuelan' },
    { name: 'Vietnam', code: 'VN', nationality: 'Vietnamese' },
    { name: 'Yemen', code: 'YE', nationality: 'Yemeni' },
    { name: 'Zambia', code: 'ZM', nationality: 'Zambian' },
    { name: 'Zimbabwe', code: 'ZW', nationality: 'Zimbabwean' }
];