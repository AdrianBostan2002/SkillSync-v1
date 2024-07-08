import { FileType } from "../../enums/file-type";

export interface Media {
    url: string;
    file?: File;
    fileType: FileType
    description?: string;   
}