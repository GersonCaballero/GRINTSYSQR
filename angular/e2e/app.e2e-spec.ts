import { GRINTSYSQRTemplatePage } from './app.po';

describe('GRINTSYSQR App', function() {
  let page: GRINTSYSQRTemplatePage;

  beforeEach(() => {
    page = new GRINTSYSQRTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
