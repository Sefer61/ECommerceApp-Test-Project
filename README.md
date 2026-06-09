## E-Ticaret Sistemi Test ve Analiz Raporu
## 1. Proje Yapısı
Proje, katmanlı mimari prensiplerine uygun olarak Core (İş Mantığı) ve Tests (Test Senaryoları) olarak iki ana bölüme ayrılmıştır.

## 2. STLC (Yazılım Test Yaşam Döngüsü)
Requirement: İş kuralları (stok, indirim, min. tutar) analiz edildi.

Test Plan: 20 test case ve dengeli test türü dağılımı planlandı.

Test Design: EP (Eşdeğerlik) ve BVA (Sınır Değer) teknikleri kullanıldı (99-100-101 TL sınırları).

Test Execution: NUnit ile Test Explorer üzerinden tüm testler koşuldu.

Test Result & Reporting: Hatalar tespit edilerek bu rapor oluşturuldu.

## 3. Uygulanan Test Metodolojileri
White Box Test: Kodun iç yapısı (karar mekanizmaları) kontrol edildi.

Black Box Test: Girdi-çıktı doğruluğu test edildi.

Gray Box Test: Stok verisi ve sepet durumu (sistem durumu) analiz edildi.

Integration Test: Cart ve OrderService sınıflarının uyumu test edildi.

## 4. Test Stratejileri
Agile Testing: TDD yaklaşımıyla her metodun testi geliştirme ile eş zamanlı yazıldı.

Risk-Based Testing: Ödeme ve sepet (Checkout) gibi kritik modüllere öncelik verildi.

Regression Testing: Düzeltilen hatalar sonrası tüm paket tekrar çalıştırıldı.

## 5. Hata (Bug) Kavramları
Error: Geliştiricinin indirim metodunda + operatörünü yanlış kullanması.

Fault: Kod içindeki hatalı matematiksel satır.

Failure: İndirimli fiyatın 80 yerine 120 gelmesi.

Defect/Bug: Testlerin yakaladığı ve bu raporda listelenen hatalar.

## 6. Test Sonuçları ve Bug Analizi

Aşağıdaki tablo, 20 adet test senaryosunun bir özetidir:

```text
| Senaryo             | Test Türü     | Durum | Açıklama                          |
|---------------------|---------------|-------|-----------------------------------|
| İndirim Hesaplama   | Black Box     |  FAIL | İndirim tutarı fiyatı artırıyor.  |
| Boş Kart Kontrolü   | White Box     |  FAIL | Geçersiz kartı onaylıyor.         |
| Stok Kontrolü       | Gray Box      |  FAIL | 0 stok kabul ediliyor.            |
| Min. Sipariş        | Integration   |  FAIL | 100 TL sınır değerde hata.        |
| Ürün Oluşturma      | Unit Test     |  PASS | Nesne doğru oluşuyor.             |
| Sepet Toplamı       | Unit Test     |  PASS | Ham fiyatlar doğru.

Not: Tablodaki FAIL sonuçları sistemdeki bilinçli hataları temsil etmektedir.
Not: Diğer 14 test, sistemin temel akışlarını doğrulamaktadır.

## Sonuç

Yapılan test süreçleri sonucunda, geliştirilen e-ticaret sisteminin temel CRUD (Ekleme, Listeleme) operasyonlarını başarıyla gerçekleştirdiği doğrulanmıştır. Ancak, **Boundary Value Analysis (Sınır Değer Analizi)** ve **Eşdeğerlik Bölütleme** teknikleri kullanılarak uygulanan testler; sistemin kritik iş mantığında (stok yönetimi, indirim hesaplama ve ödeme validasyonu) ciddi mantık hataları barındırdığını ortaya koymuştur. 

Bu hatalar, sistemin yayına alınmadan önce düzeltilmesi gereken "Defect"ler olarak raporlanmıştır. Test odaklı geliştirme (TDD) yaklaşımı sayesinde bu hatalar erken aşamada tespit edilmiş; böylece sistemin güvenilirliği ve sürdürülebilirliği güvence altına alınmıştır. Elde edilen **13 Passed / 7 Failed** skoru, projenin sadece kod yazma değil, aynı zamanda **kalite güvence (QA) disiplinlerini** uygulama başarısını da kanıtlamaktadır.










