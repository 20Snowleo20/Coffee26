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
    <div class="p-5">

        <h1 class="text-2xl mb-4">
            Вход
        </h1>

        <input
            v-model="login"
            placeholder="Логин"
            class="border p-2 mb-3 block"
        >

        <input
            v-model="password"
            type="password"
            placeholder="Пароль"
            class="border p-2 mb-3 block"
        >

        <button
            @click="signIn"
            class="border px-4 py-2"
        >
            Войти
        </button>

    </div>
</template>