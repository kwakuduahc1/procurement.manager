import { HttpErrorResponse } from "@angular/common/http";

export interface IHttpHelper<T> {
  processing: boolean;
  error: boolean;
  message: string;
  onError(err: HttpErrorResponse): void;
  onSuccess(t: T): void;
}
