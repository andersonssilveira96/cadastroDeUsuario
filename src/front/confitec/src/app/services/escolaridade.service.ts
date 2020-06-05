import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class EscolaridadeService {

    constructor(private _httpClient: HttpClient) {  }

    getAll() : Observable<any> {
        return this._httpClient.get('escolaridade');
    }
}