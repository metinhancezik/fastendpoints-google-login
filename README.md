# 🔐 Google Auth Integration with .NET 8 & FastEndpoints

This project demonstrates how to implement Google OAuth 2.0 authentication using FastEndpoints in a clean, secure, and modular way.

---

## 1. 📌 Title / Research Topic

**Integrating Google OAuth 2.0 with FastEndpoints in .NET 8**

A working demo that shows secure Google login flow with JWT generation using modern .NET technologies.

---

## 2. 🎯 Purpose / Motivation

The goal was to simplify and demonstrate external login integration in a .NET REST API.  
FastEndpoints was chosen for its minimal boilerplate and performance-focused routing.

---

## 3. 🔍 Explored Areas / Subtopics

- Google OAuth 2.0 redirect & token exchange  
- FastEndpoints usage for endpoints/middleware  
- Cookie auth vs JWT auth  
- Securing `appsettings.json`  
- .NET Authentication pipeline configuration

---

## 4. 🛠 Methodology / Approach

- Followed FastEndpoints & Microsoft docs  
- Referenced real-world blog examples  
- Performed OAuth redirect and callback testing  
- Manually set up Google Developer Console project  
- JWT tokens issued after successful login

---

## 5. 📚 Resources Used / References

- [FastEndpoints Documentation](https://fast-endpoints.com/docs)  
- [Microsoft Docs - Google Login](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins)  
- [Blog - Shoaib Tippu on Medium](https://medium.com/@shoaibtippu123/implementing-google-sign-in-via-api-in-net-8-a-step-by-step-guide-for-developers-d998efee3e1a)  
- StackOverflow, GitHub Issues, FastEndpoints Discord  

---

## 6. 🧪 Key Findings / Notes

- Google login requires `DefaultScheme = Cookie`, `DefaultChallengeScheme = Google`  
- Callback endpoint must match what is defined in Google Console  
- FastEndpoints integrates seamlessly with `UseAuthentication()` and `UseAuthorization()`  
- JWT is issued after the callback  
- Always `.gitignore` your `appsettings.json`  

---

## 7. 🖼 Google Console Setup (Step-by-Step with Screenshots)

> _Below steps show how to configure your Google Developer Console for OAuth 2.0._

**a. Search Google Console**  
![Search Google Console](https://github.com/user-attachments/assets/fceebece-7254-47fd-8432-cdffed7f9b7f)

**b. Go to Quick Access**  
![Quick Access](https://github.com/user-attachments/assets/13b8cce6-8a90-45d3-87bb-5bd1c007a262)

**c. APIs & Services**  
![APIs & Services](https://github.com/user-attachments/assets/1260a185-b91f-497e-9b30-c9b35a6baab9)

**d. Click "Create Credentials"**  
![Create Credentials](https://github.com/user-attachments/assets/f6f6c562-86b8-418e-8d1e-7560ccaf86e2)

**e. Choose "OAuth Client ID"**  
![OAuth Client ID](https://github.com/user-attachments/assets/b627c6b4-f708-41d3-83e0-5cc04ac67ec0)

**f. Configure Consent Screen**  
![Consent Screen](https://github.com/user-attachments/assets/2505ebd4-556f-45e7-8258-3b28d78b9fe3)

**g. Branding Page > Click "Get Started"**  
![Branding Page](https://github.com/user-attachments/assets/b97f4a9c-197b-46d7-aeb0-76c4f3029b0e)

**h. Project Configuration (select External)**  
![Project Configuration](https://github.com/user-attachments/assets/f352a003-e664-44ec-b739-39acddef484e)

**i. Fill details and continue**  
![Consent External](https://github.com/user-attachments/assets/205fec14-7b30-40b2-88ee-a23854b0e4a6)

**j. Notification for success**  
![Success Notification](https://github.com/user-attachments/assets/c6fd39ac-9589-493c-880f-47335e9f2dc2)

**k. Create OAuth Client**  
![Create OAuth Client](https://github.com/user-attachments/assets/08a74448-e004-4dc1-9e1c-437f1932e2f1)

**l. Select "Web Application"**  
![Web Application](https://github.com/user-attachments/assets/df46fede-5154-48c5-91cb-a428b121a00a)

**m. Set redirect URI: `https://localhost:5001/auth/callback`**  
![Redirect URI](https://github.com/user-attachments/assets/5823f717-e853-4435-80b8-2b53a47ff4b5)

---

## 8. ✅ Summary

This project shows a complete Google login flow in a FastEndpoints-based .NET 8 API, featuring clean JWT handling, secure configuration, and extensibility for future providers.

---

## 9. 🚀 Conclusion / Recommendation

This approach is modern, clean, and recommended for .NET APIs requiring third-party login.  
FastEndpoints simplifies routing logic while being fully compatible with ASP.NET Core authentication infrastructure.

---

## 👨‍💻 Author Notes

- Repo: [`fastendpoints-google-login-demo`](https://github.com/metinhancezik/fastendpoints-google-login-demo)  
- Developed by [@metinhancezik](https://github.com/metinhancezik)
