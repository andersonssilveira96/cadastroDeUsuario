import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUsuario } from '../interfaces/IUsuario';

@Injectable()
export class UsuarioService {

    constructor(private _httpClient: HttpClient) {  }

    getAll() : Observable<any> {
       return this._httpClient.get('usuario')
    }

    getById(id: number) : Observable<any> {
        return this._httpClient.get(`usuario/${id}`)
     }

    delete(id: number) : Observable<any> {
        return this._httpClient.delete(`usuario/${id}`)
    }

    post(obj: IUsuario) : Observable<any> {
        return this._httpClient.post(`usuario`, obj)
    }

    put(obj: IUsuario) : Observable<any> {
        return this._httpClient.put(`usuario/${obj.id}`, obj)
    }
}