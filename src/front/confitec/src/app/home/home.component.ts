import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { IUsuario } from '../interfaces/IUsuario';
import { IRetorno } from '../interfaces/IRetorno';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IEscolaridade } from '../interfaces/IEscolaridade';
import { FormControl, FormGroup } from '@angular/forms';
import { EscolaridadeService } from '../services/escolaridade.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public usuarios: IUsuario[];
  public usuario: IUsuario;
  public escolaridade: IEscolaridade[];
  public retorno: IRetorno;
  public form: FormGroup = new FormGroup({
    nome: new FormControl(),
    sobrenome: new FormControl(),
    email: new FormControl(),
    dataNascimento: new FormControl(),
    escolaridade: new FormControl()
  });
  
  constructor(private _usuarioService: UsuarioService,
    private _escolaridadeService: EscolaridadeService,
    private _toastr: ToastrService, 
    private _modalService: NgbModal,
    public pipeDate: DatePipe) { }

  ngOnInit(): void {
    this._usuarioService.getAll().subscribe((data) => { this.usuarios = data;  })
    this._escolaridadeService.getAll().subscribe((data) => { this.escolaridade = data;  })
  
    this.form.controls.dataNascimento.setValue(new Date().toISOString().substring(0, 10));
  }

  edit(content, id: number) {
    
   this._usuarioService.getById(id)
          .subscribe((data: IUsuario) => {
            this.usuario = data;
            this.form.controls.nome.setValue(data.nome)
            this.form.controls.sobrenome.setValue(data.sobrenome)
            this.form.controls.email.setValue(data.email)
            this.form.controls.dataNascimento.setValue(new Date(data.dataNascimento.split('T')[0]).toISOString().substring(0, 10))
            this.form.controls.escolaridade.setValue(data.escolaridadeId)
            this._modalService.open(content);
          },
          () => {
            this._toastr.warning('Erro ao tentar obter o usuário, tente novamente.');
            this._modalService.dismissAll();
          })
    
  }

  delete(id: number) {
    this._usuarioService.delete(id).subscribe((data: IRetorno) => { 
      this.retorno = data;           
      this._toastr.success(this.retorno.mensagem);  
      this.usuarios = this.usuarios.filter(x => x.id != id)
    },
    (msg) => {
      this._toastr.error(msg);  
    })      
  }

  atualizar() {
    
    if(!this.form.valid)    
      return this._toastr.warning('Formulário invalido, verifique os campos do formulário.')

      
      this.usuario.nome = this.form.controls.nome.value;
      this.usuario.sobrenome = this.form.controls.sobrenome.value;
      this.usuario.email = this.form.controls.email.value;
      this.usuario.dataNascimento = new Date(this.form.controls.dataNascimento.value).toISOString().substring(0, 10);
      this.usuario.escolaridadeId = this.form.controls.escolaridade.value;

      this._usuarioService.put(this.usuario)
          .subscribe((data: IRetorno) => {
              
              this._usuarioService.getAll().subscribe((data) => { this.usuarios = data;  })

              this._toastr.success(data.mensagem);     
              this._modalService.dismissAll();
          },
          (data) => {              
              for(var item of Object.keys(data.error)){
                this._toastr.warning(data.error[item]);
              }              
          })
  }
}
