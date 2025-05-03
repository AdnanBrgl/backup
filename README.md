# TIA_Backup – Otomatik Yedekleme Aracı

Bu proje, belirli bir klasörü zipleyerek yedekler ve önceden belirlenen yedek sayısını aşan dosyaları siler.

## Özellikler

- Belirli klasörü zip formatında yedekler
- Maksimum yedek sayısını aşanları otomatik siler
- `yedek_log.txt` ile kayıt tutar

## Kullanım

1. Projeyi Visual Studio 2022 ile aç.
2. `Program.cs` içindeki klasör yollarını ihtiyacına göre düzenle.
3. Build > Release modda derle.
4. `bin\Release\net6.0` içinde `.exe` dosyası oluşur.
5. Görev zamanlayıcıya ekleyerek her gün saat 20:38’de çalıştırabilirsin.

## Lisans
MIT
