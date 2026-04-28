# E-Ticaret Sistemi Test ve Analiz Raporu

## 1. Proje Yapısı
Proje, katmanlı mimari prensiplerine uygun olarak `Core` (İş Mantığı) ve `Tests` (Test Senaryoları) olarak iki ana bölüme ayrılmıştır.

## 2. Uygulanan Test Metodolojileri
Proje kapsamında aşağıdaki 4 farklı test yaklaşımı kullanılmıştır:
* **White Box Test:** Kodun iç yapısı (karar mekanizmaları) kontrol edilmiştir.
* **Black Box Test:** Kodun iç yapısına bakılmaksızın, girdi-çıktı doğruluğu test edilmiştir.
* **Gray Box Test:** Sistemin durumu (stok verisi, sepet içeriği) analiz edilmiştir.
* **Integration Test:** Farklı sınıfların (Cart ve OrderService) birbiriyle uyumu test edilmiştir.

## 3. Test Sonuçları ve Hata (Bug) Analizi
Toplam **10 test** uygulanmış; bunlardan **6'sı başarılı**, **4'ü başarısız** sonuçlanmıştır. Başarısızlıklar sistemdeki "bilinçli hataları" temsil eder:

| Test Türü | Senaryo | Durum | Açıklama |
| :--- | :--- | :--- | :--- |
| **Black Box** | İndirim Hesaplama | ❌ FAIL | İndirim tutarı fiyattan düşmek yerine ekleniyor. |
| **White Box** | Boş Kart Kontrolü | ❌ FAIL | Kart numarası boş olsa bile sistem ödemeyi onaylıyor. |
| **Gray Box** | Stok Kontrolü | ❌ FAIL | Stok adedi 0 olan ürün sepete eklenebiliyor. |
| **Integration** | Uçtan Uca Sipariş | ❌ FAIL | İndirim hatası nedeniyle toplam tutar yanlış hesaplanıyor. |
| **Unit Test** | Ürün Oluşturma | ✅ PASS | Ürün nesnesi ve özellikleri doğru oluşuyor. |
| **Unit Test** | Sepet Toplamı | ✅ PASS | Ürünlerin ham fiyatları doğru toplanıyor. |

## 4. Sonuç
Yapılan testler sonucunda sistemin temel işlevlerini yerine getirdiği ancak kritik iş mantığı (stok ve indirim) hataları barındırdığı tespit edilmiştir. Bu hatalar, yazılan NUnit testleri sayesinde raporlanmış ve düzeltme aşamasına hazır hale getirilmiştir.