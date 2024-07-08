import { Injectable } from "@angular/core";
import { LoadingSpinnerService } from "../../services/loading-spinner.service";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { TokenService } from "../../services/token.service";
import { environment } from "../../../environments/environment.development";

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {

    constructor(
        private loadingSpinner: LoadingSpinnerService,
        private tokenService: TokenService,
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = this.attachTokenToRequest(request);
        this.loadingSpinner.setLoading(true, request.url);

        return next.handle(request)
            .pipe(map<HttpEvent<any>, any>((evt: HttpEvent<any>) => {
                if (evt instanceof HttpResponse) {
                    this.loadingSpinner.setLoading(false, request.url);
                }
                return evt;
            }));
    }

    private attachTokenToRequest(request: HttpRequest<unknown>) {
        let token = this.tokenService.jwtToken;
        if (token != '' && this.checkIfShouldAttachToken(request)) {
            return request.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }
        return request;
    }

    private checkIfShouldAttachToken(request: HttpRequest<unknown>) {
        return request.url.includes(environment.apiUrl);
    }
}