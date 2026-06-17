<template>
  <div>
    <main
      class="text-slate-700 bg-cover bg-center bg-no-repeat"
      :style="{ backgroundImage: `url(${bgfieldandsky})` }"
    >
      <div class="bg-white/50 p-4">
        <section>
          <h1 class="text-center py-2 md:text-2xl text-sm font-semibold">Контакты</h1>
          <h2 class="text-center py-2 md:text-xl text-sm font-semibold">
            Есть вопросы или предложения? <br />Форма обратной связи уже здесь
          </h2>
        </section>

        <form @submit.prevent="handleSubmit">
          <section class="bg-white border rounded-lg p-3 md:p-4 space-y-3 text-sm border-slate-900">
            <h3 class="font-semibold text-center md:text-left">Заполните данные для отправки</h3>

            <!-- Имя -->
            <div>
              <label for="fullname" class="block mb-1 text-sm">Имя <span class="text-red-500">*</span></label>
              <input id="fullname" v-model="form.fullname" type="text" placeholder="Иванов Иван Иванович"
                class="w-full border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                @input="validateField('fullname')" />
              <p v-if="errors.fullname" class="text-red-600 text-xs mt-1">{{ errors.fullname }}</p>
            </div>

            <!-- Телефон -->
            <div>
              <label for="number" class="block mb-1 text-sm">Номер телефона <span class="text-red-500">*</span></label>
              <input id="number" v-model="form.number" type="tel" placeholder="+7 (___) ___-__-__"
                class="w-full border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                @input="validateField('number')" />
              <p v-if="errors.number" class="text-red-600 text-xs mt-1">{{ errors.number }}</p>
            </div>

            <!-- Email -->
            <div>
              <label for="email" class="block mb-1 text-sm">Данные почты <span class="text-red-500">*</span></label>
              <input id="email" v-model="form.email" type="email" placeholder="youremail@yours.com"
                class="w-full border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                @input="validateField('email')" />
              <p v-if="errors.email" class="text-red-600 text-xs mt-1">{{ errors.email }}</p>
            </div>

            <!-- Тематика -->
            <div>
              <label for="topic" class="block mb-1 text-sm">Тематика обращения</label>
              <select id="topic" v-model="form.topic"
                class="w-full border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500">
                <option value="">Выберите тему</option>
                <option>Вопрос к структуре сайта</option>
                <option>Вопросы по рецептам</option>
                <option>Предложение по сайту</option>
                <option>Предложение по другой тематике</option>
              </select>
            </div>

            <!-- Сообщение -->
            <textarea id="message" v-model="form.message" rows="4" placeholder="Введите ваше сообщение"
              class="w-full border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"></textarea>

            <!-- Согласие -->
            <div class="flex items-center">
              <input type="checkbox" id="consent" v-model="form.consent"
                class="h-4 w-4 border rounded focus:ring-slate-700" @change="validateField('consent')" />
              <label for="consent" class="text-sm px-2">
                Согласен на обработку данных <span class="text-red-500">*</span>
              </label>
            </div>
            <p v-if="errors.consent" class="text-red-600 text-xs mt-1">{{ errors.consent }}</p>

            <!-- Кнопки -->
            <div class="flex flex-col sm:flex-row sm:justify-between gap-6">
              <button type="submit" :disabled="isSubmitting"
                class="w-full sm:w-1/2 text-white mt-1 py-2 rounded-lg bg-slate-700 hover:bg-slate-900 active:bg-slate-500 disabled:opacity-50 disabled:cursor-not-allowed">
                {{ isSubmitting ? 'Отправка...' : 'Отправить' }}
              </button>
              
              <!-- ИСПРАВЛЕНО: type="button" вместо type="reset" -->
              <button type="button" @click="handleReset"
                class="w-full sm:w-1/2 text-slate-700 mt-1 py-2 rounded-lg bg-gray-300 hover:bg-gray-500 active:bg-slate-100">
                Очистить
              </button>
            </div>
          </section>
        </form>

        <div class="flex items-center justify-center py-12">
          <iframe
            src="https://yandex.ru/map-widget/v1/?um=constructor%3A576e9ce95c1877e555958ee637c2cdbd8922fa38c2f551cb14a25631919fc552&amp;source=constructor"
            width="80%" height="400" frameborder="0"></iframe>
        </div>
      </div>
    </main>
  </div>
</template>

<script>
import bgfieldandsky from '../assets/image/bg_fieldandsky.jpg'

export default {
  name: "Contacts",
  data() {
    return {
      bgfieldandsky,
      isSubmitting: false, // Флаг, чтобы блокировать кнопку во время отправки
      form: {
        fullname: "",
        number: "",
        email: "",
        topic: "",
        message: "",
        consent: false,
      },
      errors: {
        fullname: "",
        number: "",
        email: "",
        consent: "",
      },
    };
  },
  mounted() {
    console.log("Страница контактов загружена");
  },
  methods: {
    // ... (Твои методы validateField, validateForm, validateEmail, validatePhone остаются БЕЗ ИЗМЕНЕНИЙ) ...
    validateField(field) {
      this.errors[field] = ""; 
      switch (field) {
        case "fullname":
          if (!this.form.fullname.trim()) this.errors.fullname = "Имя обязательно для заполнения";
          break;
        case "number":
          if (!this.form.number.trim()) this.errors.number = "Номер телефона обязателен";
          else if (!this.validatePhone(this.form.number)) this.errors.number = "Введите корректный номер телефона";
          break;
        case "email":
          if (!this.form.email.trim()) this.errors.email = "Email обязателен";
          else if (!this.validateEmail(this.form.email)) this.errors.email = "Введите корректный email";
          break;
        case "consent":
          if (!this.form.consent) this.errors.consent = "Необходимо согласие на обработку данных";
          break;
      }
    },
    validateForm() {
      this.validateField("fullname");
      this.validateField("number");
      this.validateField("email");
      this.validateField("consent");
      return !Object.values(this.errors).some((error) => error !== "");
    },
    validateEmail(email) {
      const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return re.test(email);
    },
    validatePhone(phone) {
      const digits = phone.replace(/\D/g, "");
      return digits.length >= 10;
    },

    // 🔥 ГЛАВНОЕ ИЗМЕНЕНИЕ: Реальная отправка на бэкенд
    async handleSubmit() {
      if (!this.validateForm()) {
        alert("Пожалуйста, исправьте ошибки в форме");
        return;
      }

      this.isSubmitting = true; // Блокируем кнопку

      try {
        // Убедись, что порт (5000) совпадает с портом твоего ASP.NET Core
        const response = await fetch('http://localhost:5123/contact', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(this.form)
        });

        if (response.ok) {
          alert("Сообщение успешно отправлено!");
          this.handleReset(); // Очищаем форму после успеха
        } else {
          alert("Произошла ошибка на сервере. Попробуйте позже.");
        }
      } catch (error) {
        console.error("Ошибка сети:", error);
        alert("Не удалось связаться с сервером. Проверьте, запущен ли backend.");
      } finally {
        this.isSubmitting = false; // Разблокируем кнопку в любом случае
      }
    },

    handleReset() {
      this.form = {
        fullname: "",
        number: "",
        email: "",
        topic: "",
        message: "",
        consent: false,
      };
      this.errors = {
        fullname: "",
        number: "",
        email: "",
        consent: "",
      };
      console.log("Форма очищена");
    },
  },
};
</script>

<style scoped>
</style>