<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const login = ref('')
const password = ref('')

async function signIn() {
if (
    !login.value.trim() ||
    !password.value.trim()
) {
    alert(
        'Введите логин и пароль'
    )
    return
}
    const response = await fetch(
        'http://localhost:5123/login',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                login: login.value,
                password: password.value
            })
        }
    )

   if (response.ok) {

    const data =
        await response.json()

    localStorage.setItem(
        'user',
        data.user
    )

    localStorage.setItem(
        'token',
        data.token
    )

    router.push('/profile')
}
    else {
        alert('Неверный логин или пароль')
    }
}
</script>

<template>
    <div class="min-h-screen flex items-center justify-center bg-blue-100 from-slate-100 to-slate-200 p-5">

        <div class="bg-white rounded-2xl shadow-xl p-8 w-full max-w-md">

            <h2 class="text-3xl font-bold text-slate-800 mb-6 text-center">
                Вход
            </h2>

            <input
                v-model="login"
                placeholder="Логин"
                class="w-full border border-gray-300 rounded-3xl p-3 mb-4 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400"
            >

            <input
                v-model="password"
                type="password"
                placeholder="Пароль"
                class="w-full border border-gray-300 rounded-3xl p-3 mb-6 block focus:outline-none focus:ring-2 focus:ring-slate-500 focus:border-transparent transition-all placeholder-gray-400"
            >

            <button
                @click="signIn"
                class="w-full bg-slate-700 text-white font-semibold rounded-3xl py-3 px-4 hover:bg-slate-900 active:bg-slate-600 transition-all shadow-md hover:shadow-lg"
            >
                Войти
            </button>

        </div>

    </div>
</template>