import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MhnCampaignListComponent } from './mhn-campaign-list.component';

describe('MhnCampaignListComponent', () => {
  let component: MhnCampaignListComponent;
  let fixture: ComponentFixture<MhnCampaignListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MhnCampaignListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MhnCampaignListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
