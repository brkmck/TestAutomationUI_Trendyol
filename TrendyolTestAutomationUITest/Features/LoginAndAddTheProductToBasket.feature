Feature: LoginAndAddTheProductToBasket
	trendyol sitesine gidilir login olunur, tüm butik imajları kontrol edilir,
	rastgele butiğe gidilerek ürün detayından sepete eklenir, karşılaşılan bütün hatalar loglara yazdırılır

Background: 
	* 'Chrome' browser açlır

Scenario: LoginAndAddTheProductToBasket
	* 'https://www.trendyol.com/' sitesine gidilir
	* Anasayfadaki popup kapatılır
	* Giriş Yap butonuna tıklanır
	* Email adresi 'test@gmail.com' girilir
	* Şifre 'Test123' girilir
	* Giriş Yap butonuna tıklanır ve login olunur
	* Giriş yaptıktan sonra gelen popup kapanır
	* Kategorilere tıklanarak butiklerin yüklendiği kontrol edilir
	* Rastgele bir kategoriye tıklanır
	* Rastgele bir butiğe tıklanarak ürünlerin görselleri kontrol edilir
	* Rastgele bir ürüne tıklanır
	* Ürün sepete eklenir