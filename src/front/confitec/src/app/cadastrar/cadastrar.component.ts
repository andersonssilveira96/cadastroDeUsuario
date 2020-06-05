import { Component, OnInit } from '@angular/core';
import { EscolaridadeService } from '../services/escolaridade.service';
import { IEscolaridade } from '../interfaces/IEscolaridade';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IUsuario } from '../interfaces/IUsuario';
import { UsuarioService } from '../services/usuario.service';
import { IRetorno } from '../interfaces/IRetorno';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.scss']
})
export class CadastrarComponent implements OnInit {

  public escolaridade: IEscolaridade[];
  public form: FormGroup = new FormGroup({
    nome: new FormControl(),
    sobrenome: new FormControl(),
    email: new FormControl(),
    dataNascimento: new FormControl(),
    escolaridade: new FormControl('')
  });
  
  constructor(private _escolaridadeService: EscolaridadeService, 
    private _usuarioService: UsuarioService, 
    private _toastr: ToastrService,
    private _router: Router) { }

  ngOnInit(): void {
    this._escolaridadeService.getAll().subscribe((data) => this.escolaridade = data);
    let data = new Date();
    this.form.controls.dataNascimento.setValue(new Date(data.getFullYear(), data.getMonth(), data.getDate()).toISOString().substring(0, 10));
  }
   
  cadastrar() {
   
    if(!this.form.valid)    
      return this._toastr.warning('Formulário invalido, verifique os campos do formulário.')
    

    let usuario: IUsuario = {
      id: 0,
      nome: this.form.controls.nome.value,
      sobrenome: this.form.controls.sobrenome.value,
      email: this.form.controls.email.value,
      dataNascimento: this.form.controls.dataNascimento.value,     
      escolaridadeId: this.form.controls.escolaridade.value
    }

    this._usuarioService.post(usuario)
          .subscribe((data: IUsuario) => {
              this._toastr.success('Usuário inserido com sucesso!');     
              this._router.navigate(['/home']);        
          },
          (data) => {              
              for(var item of Object.keys(data.error)){
                this._toastr.warning(data.error[item]);
              }              
          })

  }
}
