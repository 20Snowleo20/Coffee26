<script setup>
import { ref, onMounted, watch } from 'vue'

// --- СОСТОЯНИЕ ---
// 'register' | 'login' | 'profile'
const view = ref('register') 
const user = ref(null)

// --- ФОРМЫ ---
const regLogin = ref('')
const regPassword = ref('')

const logLogin = ref('')
const logPassword = ref('')

// --- ИНИЦИАЛИЗАЦИЯ ---
onMounted(() => {
    const storedUser = localStorage.getItem('user')
    if (storedUser) {
        user.value = storedUser
        view.value = 'profile'
    } else {
        user.value = null
        view.value = 'register' // Неавторизованный попадает на регистрацию
    }
})

// Очищаем поля при переключении вкладок, чтобы формы были пустыми
watch(view, () => {
    regLogin.value = ''
    regPassword.value = ''
    logLogin.value = ''
    logPassword.value = ''
})

// --- ЛОГИКА РЕГИСТРАЦИИ (из Register.vue) ---
async function register() {
    if (!regLogin.value.trim() || !regPassword.value.trim()) {
        alert('Введите логин и пароль')
        return
    }

    const response = await fetch('http://localhost:5123/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            login: regLogin.value,
            password: regPassword.value
        })
    })

    if (response.ok) {
        alert('Регистрация выполнена')
        view.value = 'login' // Переключаем на форму входа
    } else {
        alert('Пользователь уже существует')
    }
}

// --- ЛОГИКА ВХОДА (из Login.vue) ---
async function signIn() {
    if (!logLogin.value.trim() || !logPassword.value.trim()) {
        alert('Введите логин и пароль')
        return
    }

    const response = await fetch('http://localhost:5123/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            login: logLogin.value,
            password: logPassword.value
        })
    })

    if (response.ok) {
        const data = await response.json()
        
        // Сохраняем в localStorage
        localStorage.setItem('user', data.user)
        localStorage.setItem('token', data.token)
        
        // Обновляем реактивное состояние Vue
        user.value = data.user
        view.value = 'profile' // Переключаем на профиль
    } else {
        alert('Неверный логин или пароль')
    }
}

// --- ЛОГИКА ВЫХОДА (из Profile.vue) ---
function logout() {
    localStorage.removeItem('user')
    localStorage.removeItem('token')
    
    user.value = null
    view.value = 'login' // После выхода показываем форму входа
}
</script>

<template>
    <div class="min-h-screen flex items-center justify-center bg-blue-100 p-5">
        <div class="bg-white rounded-2xl shadow-xl p-8 w-full max-w-md">

            <!-- СОСТОЯНИЕ 1: ПРОФИЛЬ -->
            <div v-if="view === 'profile'">
                <h2 class="text-3xl font-bold text-slate-800 mb-6 text-center">
                    Вы успешно авторизованы
                </h2>
                <p class="text-center text-slate-600 mb-6">
                    Пользователь:
                    <span class="font-semibold text-slate-800">{{ user }}</span>
                </p>
                <button
                    @click="logout"
                    class="w-full bg-slate-700 text-white font-semibold rounded-3xl py-3 px-4 hover:bg-slate-900 active:bg-slate-600 transition-all shadow-md hover:shadow-lg"
                >
                    Выйти
                </button>
            </div>

            <!-- СОСТОЯНИЕ 2: РЕГИСТРАЦИЯ -->
            <div v-else-if="view === 'register'">
                <h2 class="text-3xl font-bold text-slate-800 mb-6 text-center">Регистрация</h2>
                <input v-model="regLogin" placeholder="Логин"
                    class="w-full border border-gray-300 rounded-3xl p-3 mb-4 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400">
                <input v-model="regPassword" type="password" placeholder="Пароль"
                    class="w-full border border-gray-300 rounded-3xl p-3 mb-6 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400">
                <button @click="register"
                    class="w-full bg-slate-700 text-white font-semibold rounded-3xl py-3 px-4 hover:bg-slate-900 active:bg-slate-600 transition-all shadow-md hover:shadow-lg">
                    Зарегистрироваться
                </button>
                <div class="mt-6 text-center text-sm text-gray-600">
                    Уже есть аккаунт?
                    <a href="#" @click.prevent="view = 'login'" class="text-slate-700 font-semibold hover:text-slate-900 underline">Войти</a>
                </div>
            </div>

            <!-- СОСТОЯНИЕ 3: ВХОД -->
            <div v-else-if="view === 'login'">
                <h2 class="text-3xl font-bold text-slate-800 mb-6 text-center">Вход</h2>
                <input v-model="logLogin" placeholder="Логин"
                    class="w-full border border-gray-300 rounded-3xl p-3 mb-4 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400">
                <input v-model="logPassword" type="password" placeholder="Пароль"
                    class="w-full border border-gray-300 rounded-3xl p-3 mb-6 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400">
                <button @click="signIn"
                    class="w-full bg-slate-700 text-white font-semibold rounded-3xl py-3 px-4 hover:bg-slate-900 active:bg-slate-600 transition-all shadow-md hover:shadow-lg">
                    Войти
                </button>
                <div class="mt-6 text-center text-sm text-gray-600">
                    Нет аккаунта?
                    <a href="#" @click.prevent="view = 'register'" class="text-slate-700 font-semibold hover:text-slate-900 underline">Зарегистрироваться</a>
                </div>
            </div>

        </div>
    </div>
</template>