# Teck PEAK — Tiếng Việt / English

Giữ giao diện Famicom của bản trước, thêm gói dịch dùng hoàn toàn ngoại tuyến.

## Cài và đổi ngôn ngữ

1. Đóng PEAK. Giải nén toàn bộ ZIP vào thư mục mới.
2. Mở Teck-PEAK.exe → Thiết lập → chọn đúng thư mục PEAK.
3. Giữ các mod muốn dùng, lưu rồi bấm CÀI MOD. Gói dịch được thêm tự động cho mọi lựa chọn mod.
4. Mở game qua Steam, vào lobby rồi bấm F7. Mặc định dùng tiếng Việt.
5. Bấm **F10** hoặc nút **Tiếng Việt | English** ở đầu menu F7 để chuyển ngôn ngữ. F8 vẫn là camera quan sát, không bị đổi chức năng.

Lựa chọn được lưu trong `BepInEx/config/teck.peak.bilingual.cfg`:

```ini
[Language]
Language = vi
SwitchLanguageKey = F10
```

Đặt `Language = en` khi game đã đóng để dùng English từ lần mở tiếp theo. Phím đổi cũng có thể chỉnh trong mục cấu hình Teck PEAK của menu F7.

## Phạm vi

| Thành phần | Phần được xử lý |
| --- | --- |
| PEAK Troll Mod / F7 | Thanh mục, nút, mô tả, quyền sử dụng, trạng thái, cấu hình, công cụ vật phẩm và kịch bản. |
| PEAK Unlimited | Menu F2, chú thích và thiết lập hiển thị qua F7. |
| ItemInfo | Chữ thông tin vật phẩm, hiệu ứng và trạng thái do mod tạo. |
| Healing Campfires | Tên và mô tả cấu hình hiển thị trong F7; mod này là lựa chọn tùy chọn. |
| Start With Backpacks | Phần hiển thị/cấu hình nếu mod cung cấp; không tự tạo thêm menu cho tính năng không có menu riêng. |

Gói có hơn 1.300 mục từ/cụm dịch. Tên gốc của mod, Steam, Photon, Scoutmaster và mã kỹ thuật được giữ khi cần. Tên vật phẩm đã biết có bản dịch; vật phẩm mới hoặc tên từ mod khác có thể vẫn hiện tiếng Anh. Tìm vật phẩm bằng tên tiếng Anh gốc trong ô tìm kiếm F7.

Đây là lớp dịch **phần hiển thị của bộ mod**, không phải Việt hóa toàn bộ game PEAK. Khóa cấu hình, mã vật phẩm, dữ liệu lưu, lệnh mạng, mã phòng và nhật ký kỹ thuật không được dịch. Ô nhập không bị sửa. English dùng trực tiếp chữ gốc; chữ động chưa có bản dịch sẽ giữ nguyên thay vì đoán nội dung.

## Kiểm tra

Đã biên dịch với thư viện PEAK đang cài; kiểm thử dịch, đổi về English, số động, thẻ màu, xuống dòng, tên kỹ thuật và bộ cài. Báo cáo trong LOCALE-TESTS.txt, TEST-RESULTS.txt và TRANSLATION-AUDIT.tsv. Báo cáo đối chiếu chuỗi tĩnh không chứng minh chữ đã hiển thị đúng trong Unity.

**Chưa kiểm chứng trực tiếp mọi trang và dấu tiếng Việt trong một lobby PEAK.** Nếu chữ bị thiếu dấu hoặc quá dài, chuyển English bằng F10 và gửi ảnh cùng tên trang để sửa đúng chỗ. Không dùng bản launcher cũ để cài lại vì bản đó chưa có gói dịch.

## English

Close PEAK, extract the whole ZIP, choose your PEAK folder and click CÀI MOD.
Open the game through Steam. Press F7 for the mod menu and F10 to switch
between Vietnamese and English; the selection persists. The F7 header also
has a language button. F8 remains the spectator camera shortcut.

The offline dictionary covers mod display captions, descriptions and supported
mod-created text. It does not alter configuration identifiers, network data,
text inputs or the base game's localization. Unknown runtime text falls back
to the original. Search items using their original English names. Full live
rendering and every localized mod page have not yet been verified in-game.
