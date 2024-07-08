import { FileType } from "../../enums/file-type"

export interface UploadedFile {
    url: string,
    file?: File
    type?: FileType
}