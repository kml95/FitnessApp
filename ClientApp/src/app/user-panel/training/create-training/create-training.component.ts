import { Component, OnInit } from '@angular/core';
import { TrainingAim } from 'src/app/shared/models/training.interface';
import { Router } from '@angular/router';
import { TrainingService } from 'src/app/shared/services/training.service';

@Component({
  selector: 'app-create-training',
  templateUrl: './create-training.component.html',
  styleUrls: ['./create-training.component.scss']
})
export class CreateTrainingComponent implements OnInit {

  showTrainingForm = false;
  showMainPage = true;

  model: {
    name: string,
    sex: string,
    days: number,
    trainingAim: TrainingAim;
  };

  constructor(private trainingService: TrainingService, private router: Router) {
    this.model = { name: null, sex: null, days: null, trainingAim: null };
  }

  ngOnInit() {
  }

  onSubmit() {
    switch (this.model.trainingAim) {
      case TrainingAim.MASS:
        this.model.name = 'Wzrost masy mięśniowej';
        break;
      case TrainingAim.REDUCTION:
        this.model.name = 'Uzyskanie wyrzeźbionej sylwetki';
        break;
      case TrainingAim.STRENGTH:
        this.model.name = 'Wzrost siły fizycznej';
        break;
    }
    this.trainingService.create(this.model.name, this.model.days, this.model.trainingAim)
      .subscribe(() => {
        console.log('Udało się pomyślnie stworzyć');
        this.router.navigate(['/user-panel/trening']);
      });
  }

}
