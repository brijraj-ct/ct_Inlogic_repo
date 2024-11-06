import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import Swal from 'sweetalert2';

@Injectable()
export class ValidatorInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap((event) => {
        if (event instanceof HttpResponse) {
          const response = event.body;
          if (response && response.success === false) {
            // Trigger Swell popup with message and errors
            Swal.fire({
              title: 'Error',
              text:
                response?.errors?.length > 0
                  ? response.errors
                  : response.message
                  ? response.message
                  : 'An Error Occurred',
              icon: 'error',
            });
          }
        }
      })
    );
  }
}
