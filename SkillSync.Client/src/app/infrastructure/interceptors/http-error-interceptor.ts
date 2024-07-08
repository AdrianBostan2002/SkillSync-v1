import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { NotificationService } from "../../services/notification.service";
import { LoadingSpinnerService } from "../../services/loading-spinner.service";
import { LocalStorageService } from "../../services/local-storage.service";
import { Router } from "@angular/router";
import { TokenService } from "../../services/token.service";

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
    constructor(
        private tokenService: TokenService,
        private localStorageService: LocalStorageService,
        private router: Router,
        private notificationService: NotificationService,
        private loadingSpinner: LoadingSpinnerService
    ) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((errorResponse: HttpErrorResponse) => {
                this.loadingSpinner.setLoading(false, request.url);
                if (errorResponse.error && errorResponse.error.IsCustom) {
                    this.notificationService.displayErrorMessage(errorResponse.error.Message, errorResponse.error.HttpCodeStatus.toString());
                }
                else {
                    if (!this.checkIfTokenIsExpired(errorResponse)) {
                        this.notificationService.displayErrorMessage('An error has occurred. Please contact administrator!', "500");
                    }
                }
                return throwError(() => errorResponse);
            })
        );
    }

    private checkIfTokenIsExpired(errorResponse: HttpErrorResponse) {
        if (errorResponse.status === HttpStatusCode.Unauthorized && this.tokenService.isTokenExpired()) {
            this.localStorageService.removeToken();
            this.notificationService.displayErrorMessage('Your session has expired. Please login again.');
            this.router.navigate(['/choose-login-provider']);
            return true;
        }
        
        return false;
    }
}