import { Component } from '@angular/core';
import { Language } from '../../shared/entities/models/language';

@Component({
  selector: 'app-language-drop-down',
  templateUrl: './language-drop-down.component.html',
  styleUrl: './language-drop-down.component.css'
})
export class LanguageDropDownComponent {
  languagesArray: Language[] = [
    { name: 'Brazilian Portuguese' },
    { name: 'Canadian French' },
    { name: 'English' },
    { name: 'French Creole' },
    { name: 'Haitian Creole' },
    { name: 'Navajo' },
    { name: 'Quechua' },
    { name: 'Spanish' },

    // Western Europe
    { name: 'Catalan' },
    { name: 'Danish' },
    { name: 'Dutch' },
    { name: 'Faroese' },
    { name: 'Finnish' },
    { name: 'Flemish' },
    { name: 'French' },
    { name: 'German' },
    { name: 'Greek' },
    { name: 'Icelandic' },
    { name: 'Italian' },
    { name: 'Norwegian' },
    { name: 'Portuguese' },
    { name: 'Spanish' },
    { name: 'UK English / British English' },

    // Central & Eastern Europe
    { name: 'Belarusian' },
    { name: 'Bosnian' },
    { name: 'Bulgarian' },
    { name: 'Croatian' },
    { name: 'Czech' },
    { name: 'Estonian' },
    { name: 'Hungarian' },
    { name: 'Latvian' },
    { name: 'Lithuanian' },
    { name: 'Macedonian' },
    { name: 'Polish' },
    { name: 'Romanian' },
    { name: 'Russian' },
    { name: 'Serbian' },
    { name: 'Slovak' },
    { name: 'Slovenian' },
    { name: 'Turkish' },
    { name: 'Ukrainian' },

    // Africa
    { name: 'Amharic (Ethiopia)' },
    { name: 'Dinka (Sudan)' },
    { name: 'Ibo (Nigeria)' },
    { name: 'Kirundi' },
    { name: 'Mandinka' },
    { name: 'Nuer (Nilo-Saharan)' },
    { name: 'Oromo (Ethiopia)' },
    { name: 'Kinyarwanda' },
    { name: 'Shona (Zimbabwe)' },
    { name: 'Somali' },
    { name: 'Swahili' },
    { name: 'Tigrigna (Ethiopia)' },
    { name: 'Wolof' },
    { name: 'Xhosa' },
    { name: 'Yoruba' },
    { name: 'Zulu' },

    // Middle East
    { name: 'Arabic' },
    { name: 'Dari' },
    { name: 'Farsi' },
    { name: 'Hebrew' },
    { name: 'Kurdish' },
    { name: 'Pashtu' },
    { name: 'Punjabi' },
    { name: 'Urdu (Pakistan)' },

    // Central Asia
    { name: 'Armenian' },
    { name: 'Azerbaijani' },
    { name: 'Georgian' },
    { name: 'Kazakh' },
    { name: 'Mongolian' },
    { name: 'Turkmen' },
    { name: 'Uzbek' },

    // Southeast Asia
    { name: 'Bengali' },
    { name: 'Cham' },
    { name: 'Chamorro (Guam)' },
    { name: 'Gujarati (India)' },
    { name: 'Hindi' },
    { name: 'Indonesian' },
    { name: 'Khmer (Cambodia)' },
    { name: 'Kmhmu (Laos)' },
    { name: 'Korean' },
    { name: 'Laotian' },
    { name: 'Malayalam' },
    { name: 'Malay' },
    { name: 'Marathi (India)' },
    { name: 'Marshallese' },
    { name: 'Nepali' },
    { name: 'Sherpa' },
    { name: 'Tamil' },
    { name: 'Thai' },
    { name: 'Tibetan' },
    { name: 'Trukese (Micronesia)' },
    { name: 'Vietnamese' },

    // Far East
    { name: 'Amoy' },
    { name: 'Burmese' },
    { name: 'Cantonese' },
    { name: 'Chinese' },
    { name: 'Chinese–Simplified' },
    { name: 'Chinese–Traditional' },
    { name: 'Chiu Chow' },
    { name: 'Chow Jo' },
    { name: 'Fukienese' },
    { name: 'Hakka (China)' },
    { name: 'Hmong' },
    { name: 'Hainanese' },
    { name: 'Japanese' },
    { name: 'Mandarin' },
    { name: 'Mien' },
    { name: 'Shanghainese' },
    { name: 'Taiwanese' },
    { name: 'Taishanese' },

    // South Pacific
    { name: 'Fijian' },
    { name: 'Palauan' },
    { name: 'Samoan' },
    { name: 'Tongan' },

    // Philippines
    { name: 'Bikol' },
    { name: 'Cebuano' },
    { name: 'Ilocano' },
    { name: 'Ilongo' },
    { name: 'Pampangan' },
    { name: 'Pangasinan' },
    { name: 'Tagalog' },
    { name: 'Visayan' }
  ];
}
