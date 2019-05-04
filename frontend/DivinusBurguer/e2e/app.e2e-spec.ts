import { DivinusBurguerPage } from './app.po';

describe('divinus-burguer App', function() {
  let page: DivinusBurguerPage;

  beforeEach(() => {
    page = new DivinusBurguerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
