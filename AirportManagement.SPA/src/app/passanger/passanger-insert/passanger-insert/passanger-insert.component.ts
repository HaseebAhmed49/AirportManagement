import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Passangers } from 'src/app/_models/Passangers';
import { PassangerService } from 'src/app/_services/passanger.service';

@Component({
  selector: 'app-passanger-insert',
  templateUrl: './passanger-insert.component.html',
  styleUrls: ['./passanger-insert.component.css']
})
export class PassangerInsertComponent implements OnInit{
  passangerDataForm: any;
  massage="";


  constructor(private formBuilder:FormBuilder,
    private passangerService:PassangerService,
    private router:Router) { }


  ngOnInit(): void {

    this.passangerDataForm = this.formBuilder.group({
      firstName: ['',[Validators.required]],
      lastName: ['',[Validators.required]],
      dateOfBirth: ['',[Validators.required]],
      countryOfResidence: ['',[Validators.required]],
      countryOfCitizenship: ['',[Validators.required]],
      passportNumber: ['',[Validators.required]],      
    });

  }


//  // Post
//  AddProjectTask(_projectTask: ProjectTask){
//   const projecttask_data = this.projecttaskForm.value;
//   this.token = localStorage.getItem("jwt");
//   this.projecttaskService.postProjectTaskData(projecttask_data,this.token).subscribe(
//     () => {
//       this.getProjectTaskList(this.token);
//       this.projecttaskForm.reset();
//       this.toastr.success('Project Task Added Successfully');
//     }, _err => {
//       this.toastr.warning('Error in Add Project Task');
//     }
//   );
// }



  Clear(_passanger: Passangers){
    this.passangerDataForm.reset();
  }
}
