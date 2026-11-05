// ========================================================
// DONET ACADEMY — DYNAMIC UI & MOTION ENGINE
// Apple & Emil Kowalski Principles • 2D SVG Rigging Mascot
// ========================================================

document.addEventListener('DOMContentLoaded', function () {
  console.log('DONET Academy Dynamic UI & 2D Rigging Engine Loaded');

  // 1. Quản lý Modal chung chuẩn Apple & Bootstrap 5
  window.openModal = function (modalId) {
    const modal = document.getElementById(modalId);
    if (modal) {
      // Đảm bảo modal luôn nằm trực tiếp dưới <body> giống _AuthModal
      // Giúp z-index modal (1065) luôn cao hơn backdrop (1050), không bao giờ bị che phủ hay mất tương tác
      if (modal.parentElement !== document.body) {
        document.body.appendChild(modal);
      }
      if (typeof bootstrap !== 'undefined' && bootstrap.Modal) {
        let bsModal = bootstrap.Modal.getOrCreateInstance(modal);
        bsModal.show();
      } else {
        modal.classList.add('show');
        modal.style.display = 'block';
        document.body.style.overflow = 'hidden';
      }
    }
  };

  window.closeModal = function (modalId) {
    const modal = document.getElementById(modalId);
    if (modal) {
      if (typeof bootstrap !== 'undefined' && bootstrap.Modal) {
        let bsModal = bootstrap.Modal.getInstance(modal);
        if (bsModal) {
          bsModal.hide();
        } else {
          modal.classList.remove('show');
          modal.style.display = 'none';
        }
      } else {
        modal.classList.remove('show');
        modal.style.display = 'none';
        document.body.style.overflow = 'auto';
      }
    }
  };

  // Dọn dẹp backdrop an toàn khi bất kỳ modal nào đóng
  document.addEventListener('hidden.bs.modal', function () {
    if (!document.querySelector('.modal.show')) {
      document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
      document.body.classList.remove('modal-open');
      document.body.style.overflow = '';
      document.body.style.paddingRight = '';
    }
  });

  // 2. Hệ thống Toast Notification mượt mà
  window.showToast = function (message, type = 'success') {
    let container = document.getElementById('donet-toast-container');
    if (!container) {
      container = document.createElement('div');
      container.id = 'donet-toast-container';
      container.style.cssText = 'position:fixed;bottom:24px;right:24px;z-index:99999;display:flex;flex-direction:column;gap:10px;pointer-events:none;';
      document.body.appendChild(container);
    }

    const toast = document.createElement('div');
    toast.style.cssText = `
      background:#FFFFFF;
      border:1px solid #E6DDCF;
      border-left:4px solid ${type === 'success' ? '#10B981' : (type === 'error' ? '#EF4444' : '#FA7E0A')};
      box-shadow:0 12px 32px rgba(0,0,0,0.12), 0 2px 6px rgba(0,0,0,0.04);
      border-radius:14px;
      padding:14px 20px;
      font-size:14px;
      font-weight:600;
      color:#1C1917;
      display:flex;
      align-items:center;
      gap:10px;
      transform:translateY(24px) scale(0.96);
      opacity:0;
      pointer-events:auto;
      transition:transform 0.3s cubic-bezier(0.16, 1, 0.3, 1), opacity 0.3s cubic-bezier(0.16, 1, 0.3, 1);
    `;
    toast.innerHTML = `<span>${message}</span>`;
    container.appendChild(toast);

    requestAnimationFrame(() => {
      toast.style.transform = 'translateY(0) scale(1)';
      toast.style.opacity = '1';
    });

    setTimeout(() => {
      toast.style.transform = 'translateY(12px) scale(0.95)';
      toast.style.opacity = '0';
      setTimeout(() => toast.remove(), 300);
    }, 3800);
  };

  // 3. Logic Auth Modal (Đăng Nhập / Đăng Ký Học Sinh & Giáo Viên)
  window.openAuthModal = function (mode = 'login') {
    window.switchAuthMode(mode);
    window.openModal('donetAuthModal');
  };

  window.closeAuthModal = function () {
    window.closeModal('donetAuthModal');
  };

  window.switchAuthMode = function (mode) {
    const segmented = document.querySelector('.auth-mode-segmented');
    const tabLogin = document.getElementById('tabModeLogin');
    const tabRegister = document.getElementById('tabModeRegister');
    const loginForm = document.getElementById('authLoginForm');
    const regStudentForm = document.getElementById('authRegisterStudentForm');
    const regTeacherForm = document.getElementById('authRegisterTeacherForm');

    if (!segmented || !tabLogin || !tabRegister) return;

    if (mode === 'login') {
      segmented.classList.remove('mode-register');
      tabLogin.classList.add('active');
      tabRegister.classList.remove('active');
      if (loginForm) loginForm.classList.remove('d-none');
      if (regStudentForm) regStudentForm.classList.add('d-none');
      if (regTeacherForm) regTeacherForm.classList.add('d-none');
    } else {
      segmented.classList.add('mode-register');
      tabRegister.classList.add('active');
      tabLogin.classList.remove('active');
      if (loginForm) loginForm.classList.add('d-none');
      const currentRole = document.getElementById('roleTabTeacher')?.classList.contains('active') ? 'teacher' : 'student';
      if (currentRole === 'teacher') {
        if (regTeacherForm) regTeacherForm.classList.remove('d-none');
        if (regStudentForm) regStudentForm.classList.add('d-none');
      } else {
        if (regStudentForm) regStudentForm.classList.remove('d-none');
        if (regTeacherForm) regTeacherForm.classList.add('d-none');
      }
    }
  };

  window.switchAuthRole = function (role) {
    const tabStudent = document.getElementById('roleTabStudent');
    const tabTeacher = document.getElementById('roleTabTeacher');
    const regStudentForm = document.getElementById('authRegisterStudentForm');
    const regTeacherForm = document.getElementById('authRegisterTeacherForm');
    const loginUsername = document.getElementById('loginUsername');

    if (role === 'teacher') {
      tabTeacher?.classList.add('active');
      tabStudent?.classList.remove('active');
      if (loginUsername) loginUsername.placeholder = 'giaovien@donet.edu.vn hoặc 0912...';
      if (regTeacherForm && !document.getElementById('authLoginForm')?.classList.contains('d-none')) {
        // Đang ở login
      } else {
        regTeacherForm?.classList.remove('d-none');
        regStudentForm?.classList.add('d-none');
      }
    } else {
      tabStudent?.classList.add('active');
      tabTeacher?.classList.remove('active');
      if (loginUsername) loginUsername.placeholder = 'hocsinh@donet.edu.vn hoặc 0987...';
      if (regStudentForm && !document.getElementById('authLoginForm')?.classList.contains('d-none')) {
        // Đang ở login
      } else {
        regStudentForm?.classList.remove('d-none');
        regTeacherForm?.classList.add('d-none');
      }
    }
  };

  window.handleDemoLogin = function (e) {
    e.preventDefault();
    const isTeacher = document.getElementById('roleTabTeacher')?.classList.contains('active');
    sessionStorage.setItem('mascot_user_logged', 'true');
    showToast(`Đăng nhập thành công với vai trò: ${isTeacher ? 'Giáo Viên' : 'Học Sinh'}! Đang tải dữ liệu...`, 'success');
    setTimeout(() => {
      window.closeAuthModal();
      window.location.href = isTeacher ? '/Teacher/Dashboard' : '/Student/Dashboard';
    }, 700);
  };

  window.handleDemoRegister = function (e, roleName) {
    e.preventDefault();
    sessionStorage.setItem('mascot_user_logged', 'true');
    showToast(`Đăng ký tài khoản ${roleName} thành công! Hệ thống đã tạo hồ sơ demo.`, 'success');
    setTimeout(() => {
      window.closeAuthModal();
      window.location.href = roleName === 'Giáo viên' ? '/Teacher/Dashboard' : '/Student/Dashboard';
    }, 800);
  };

  // 4. QUẢN LÝ BÉ CHIM HEADER CAPSULE (ĐẶT BÊN TRÁI TRANG CHỦ)
  const authCapsule = document.getElementById('authMascotCapsule');
  const mascotTrigger = document.getElementById('mascotHeaderAvatar');
  const speechBubble = document.getElementById('mascotBubble');

  // Kiểm tra cờ đã tương tác hoặc đã đăng nhập trong session
  const isInteracted = sessionStorage.getItem('mascot_interacted') === 'true';
  const isUserLogged = sessionStorage.getItem('mascot_user_logged') === 'true';

  if (speechBubble) {
    if (isInteracted || isUserLogged) {
      speechBubble.classList.add('bubble-hidden');
    } else {
      const speechLines = [
        'Học cùng tớ nhé! ✨',
        'Đăng nhập ngay bạn ơi! 🐥',
        'Chinh phục điểm 10 THPT! 🚀'
      ];
      let lineIdx = 0;
      setInterval(() => {
        if (!authCapsule?.classList.contains('is-docked') && !speechBubble.classList.contains('bubble-hidden')) {
          lineIdx = (lineIdx + 1) % speechLines.length;
          const textSpan = speechBubble.querySelector('.bubble-text');
          if (textSpan) {
            speechBubble.style.opacity = '0';
            setTimeout(() => {
              textSpan.textContent = speechLines[lineIdx];
              speechBubble.style.opacity = '1';
            }, 250);
          }
        }
      }, 5500);
    }
  }

  if (authCapsule && mascotTrigger) {
    // Khi rê chuột vào: Ngay lập tức ẩn bong bóng lời nhắc để không che bất kỳ nút nào
    authCapsule.addEventListener('mouseenter', () => {
      if (speechBubble) speechBubble.classList.add('bubble-hidden');
    });

    // Khi nhấp chuột vào Bé Chim Header:
    // Bé chim di chuyển sang bên trái và YÊN VỊ CỐ ĐỊNH, mở dải nút [Đăng Nhập | Đăng Ký]
    // Bong bóng lời nhắc tắt hoàn toàn không hiện lại
    mascotTrigger.addEventListener('click', (e) => {
      e.stopPropagation();
      sessionStorage.setItem('mascot_interacted', 'true');
      if (speechBubble) speechBubble.classList.add('bubble-hidden');

      authCapsule.classList.toggle('is-docked');
    });

    // Nhấp bên ngoài capsule thì đóng dock
    document.addEventListener('click', (e) => {
      if (!authCapsule.contains(e.target)) {
        authCapsule.classList.remove('is-docked');
      }
    });
  }

  // 5. HOẠT ẢNH 2D SVG RIGGING CHO BÉ CHIM (HEADER & HERO)
  const rigMascots = document.querySelectorAll('.oriole-rig-container');
  rigMascots.forEach((rig) => {
    // Mặc định thêm nhún nhảy squash & stretch
    rig.classList.add('oriole-body-bounce');

    // Luân chuyển ngẫu nhiên nhún nhảy và đứng yên thở nhẹ
    setInterval(() => {
      if (!rig.dataset.isHovered && !rig.dataset.isClicked) {
        if (Math.random() > 0.4) {
          rig.classList.add('oriole-body-bounce');
        } else {
          rig.classList.remove('oriole-body-bounce');
        }
      }
    }, 6000);

    // Khi rê chuột vào (Hover): Chọn ngẫu nhiên giữa vẫy cánh chào tươi vui hoặc nghiêng đầu ngại ngùng
    rig.addEventListener('mouseenter', () => {
      rig.dataset.isHovered = 'true';
      rig.classList.remove('oriole-body-bounce');
      if (Math.random() > 0.5) {
        rig.classList.add('mascot-waving');
      } else {
        rig.classList.add('mascot-shy');
      }
    });

    rig.addEventListener('mouseleave', () => {
      rig.dataset.isHovered = '';
      rig.classList.remove('mascot-waving', 'mascot-shy');
      rig.classList.add('oriole-body-bounce');
    });
  });

  // Sự kiện nhấp vào Bé Chim ở Hero Banner: Vỗ cánh mở rộng & phóng bay zoom out đến trang AI Tutor
  const heroRig = document.querySelector('.oriole-hero-wrapper .oriole-rig-hero');
  if (heroRig) {
    heroRig.addEventListener('click', (e) => {
      e.preventDefault();
      heroRig.dataset.isClicked = 'true';
      heroRig.classList.remove('mascot-waving', 'mascot-shy', 'oriole-body-bounce');
      heroRig.classList.add('oriole-fly-zoom');
      showToast('Bé Chim Hoàng Anh vỗ cánh bay dẫn đường bạn đến Trợ Lý AI Tutor 24/7! ✨', 'info');
      setTimeout(() => {
        window.location.href = '/Student/AiTutor';
      }, 700);
    });
  }
});
