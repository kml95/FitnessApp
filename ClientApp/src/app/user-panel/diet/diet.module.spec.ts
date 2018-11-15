import { DietModule } from './diet.module';

describe('DietModule', () => {
  let dietModule: DietModule;

  beforeEach(() => {
    dietModule = new DietModule();
  });

  it('should create an instance', () => {
    expect(dietModule).toBeTruthy();
  });
});
